#include "MenuRequestHandler.h"
#include "LoginRequestHandler.h"
#include "DatabaseException.h"
#include "RoomManagerException.h"
#include "JSONHandlers.h"
#include "RoomMemberRequestHandler.h"
#include "RoomAdminRequestHandler.h"

#define SIGNOUT_CODE "111"
#define GETROOMS_CODE "112"
#define GETINROOMS_CODE "113"
#define HIGHSCORE_CODE "114"
#define JOINROOM_CODE "115"
#define CREATEROOM_CODE "116"
#define GETSTATS_CODE "117"
#define SIGNOUT_RESPONSE "211"
#define GETROOMS_RESPONE "212"
#define GETINROOMS_RESPONSE "213"
#define HIGHSCORE_RESPONSE "214"
#define JOINROOM_RESPONSE "215"
#define CREATEROOM_RESPONSE "216"
#define GETSTATS_RESPONSE "217"
#define NON_CODE_CHAR 3
#define STATUS_SUCCESS 0
#define STATUS_ROOM_ISSUE 1
#define STATUS_DATABASE_ISSUE 2

MenuRequestHandler::MenuRequestHandler(LoggedUser user, RoomManager & manager, HighscoreTable & highscoreTable, RequestHandlerFactory * handlerFactory, LoginManager& lManager, IDatabase& db) : m_user(user), m_roomManager(manager), m_highscoreTable(highscoreTable), m_handlerFactory(handlerFactory), m_loginManager(lManager), m_database(db)
{}

bool MenuRequestHandler::isRequestRelevant(const Request & request)
{
	if (!request.buffer.rfind(SIGNOUT_CODE, 0) || !request.buffer.rfind(GETROOMS_CODE, 0) || !request.buffer.rfind(GETINROOMS_CODE, 0) || !request.buffer.rfind(HIGHSCORE_CODE, 0) || !request.buffer.rfind(JOINROOM_CODE, 0) || !request.buffer.rfind(CREATEROOM_CODE, 0) || !request.buffer.rfind(GETSTATS_CODE, 0))
	{
		return true;
	}
	return false;
}

RequestResult MenuRequestHandler::handleRequest(const Request & request)
{
	if (!request.buffer.rfind(SIGNOUT_CODE, 0))
	{
		return signout(request);
	}
	if (!request.buffer.rfind(GETROOMS_CODE, 0))
	{
		return getRooms(request);
	}
	if (!request.buffer.rfind(GETINROOMS_CODE, 0))
	{
		return getPlayersInRoom(request);
	}
	if (!request.buffer.rfind(HIGHSCORE_CODE, 0))
	{
		return getHighscores(request);
	}
	if (!request.buffer.rfind(JOINROOM_CODE, 0))
	{
		return joinRoom(request);
	}
	if (!request.buffer.rfind(CREATEROOM_CODE, 0))
	{
		return createRoom(request);
	}
	return getStats(request);
}

RequestResult MenuRequestHandler::signout(const Request & request)
{	// There are no interactions with the DB or ways for LoginManager to throw an exception here, so no try clause.
	RequestResult resp;
	m_loginManager.logout(m_user);
	LogoutResponse success;
	success.status = STATUS_SUCCESS;
	std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
	msg = SIGNOUT_RESPONSE + msg;
	resp.newHandler = m_handlerFactory->createLoginRequestHandler();
	resp.response = msg;
	return resp;
}

RequestResult MenuRequestHandler::getRooms(const Request & request)
{
	RequestResult resp;
	GetRoomsResponse success;
	success.status = STATUS_SUCCESS;
	success.rooms = m_roomManager.getRooms();
	std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
	msg = GETROOMS_RESPONE + msg;
	resp.newHandler = nullptr;
	resp.response = msg;
	return resp;
}

RequestResult MenuRequestHandler::getPlayersInRoom(const Request & request)
{
	RequestResult resp;
	std::string serializedRequest = request.buffer.substr(NON_CODE_CHAR);
	GetPlayersInRoomRequest req = JsonRequestPacketDeserializer::deserializeGetPlayerRequest(serializedRequest);
	GetPlayersInRoomResponse success;
	success.players = m_roomManager.getRooms()[req.roomId]->getAllUsers();
	std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
	msg = GETINROOMS_RESPONSE + msg;
	resp.newHandler = nullptr;
	resp.response = msg;
	return resp;
}

RequestResult MenuRequestHandler::getHighscores(const Request & request)
{
	RequestResult resp;
	std::string serializedRequest = request.buffer.substr(NON_CODE_CHAR);
	HighscoreResponse success;
	success.status = STATUS_SUCCESS;
	success.highscores = m_highscoreTable.getHighscores();
	std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
	msg = HIGHSCORE_RESPONSE + msg;
	resp.newHandler = nullptr;
	resp.response = msg;
	return resp;
}

RequestResult MenuRequestHandler::joinRoom(const Request & request)
{
	RequestResult resp;
	std::string serializedRequest = request.buffer.substr(NON_CODE_CHAR);
	JoinRoomRequest req = JsonRequestPacketDeserializer::deserializeJoinRoomRequest(serializedRequest);
	try
	{
		std::shared_ptr<Room> room = m_roomManager.joinRoom(req.roomId, m_user);
		JoinRoomResponse success;
		success.status = STATUS_SUCCESS;
		std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
		msg = JOINROOM_RESPONSE + msg;
		resp.newHandler = m_handlerFactory->createRoomMemberRequestHandler(m_user, room);
		resp.response = msg;
		return resp;
	}
	catch (RoomManagerException&)
	{
		JoinRoomResponse success;
		success.status = STATUS_ROOM_ISSUE;
		std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
		msg = JOINROOM_RESPONSE + msg;
		resp.newHandler = nullptr;
		resp.response = msg;
		return resp;
	}
}

RequestResult MenuRequestHandler::createRoom(const Request & request)
{
	RequestResult resp;
	std::string serializedRequest = request.buffer.substr(NON_CODE_CHAR);
	CreateRoomRequest req = JsonRequestPacketDeserializer::deserializeCreateRoomRequest(serializedRequest);
	try
	{
		RoomData metadata;
		metadata.name = req.roomName;
		metadata.maxPlayers = req.maxUsers;
		metadata.timePerQuestion = req.answerTimeout;
		metadata.numOfQuestions = req.questionCount;
		std::shared_ptr<Room> room = m_roomManager.createRoom(m_user, metadata);
		CreateRoomResponse success;
		success.status = STATUS_SUCCESS;
		success.id = room->getMetadata().id;
		std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
		msg = CREATEROOM_RESPONSE + msg;
		resp.newHandler = m_handlerFactory->createRoomAdminRequestHandler(m_user, room);;
		resp.response = msg;
		return resp;
	}
	catch (RoomManagerException&)
	{
		CreateRoomResponse success;
		success.status = STATUS_ROOM_ISSUE;
		std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
		msg = CREATEROOM_RESPONSE + msg;
		resp.newHandler = nullptr;
		resp.response = msg;
		return resp;
	}
}

RequestResult MenuRequestHandler::getStats(const Request& request)
{
	RequestResult resp;
	try
	{
		GetStatsResponse success;
		success.status = STATUS_SUCCESS;
		success.stats = m_database.getPlayerStats(m_user.getUsername());
		std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
		msg = GETSTATS_RESPONSE + msg;
		resp.newHandler = nullptr;
		resp.response = msg;
		return resp;
	}
	catch (DatabaseException&)
	{
		GetStatsResponse success;
		success.status = STATUS_DATABASE_ISSUE;
		std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
		msg = GETSTATS_RESPONSE + msg;
		resp.newHandler = nullptr;
		resp.response = msg;
		return resp;
	}
}