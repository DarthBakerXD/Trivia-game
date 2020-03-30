#include "RoomAdminRequestHandler.h"
#include "LoginRequestHandler.h"
#include "DatabaseException.h"
#include "RoomManagerException.h"
#include "JSONHandlers.h"
#include "MenuRequestHandler.h"
#include "GameRequestHandler.h"

#define CLOSEROOM_CODE "121"
#define STARTGAME_CODE "122"
#define GETROOMSTATE_CODE "123"
#define CLOSEROOM_RESPONSE "221"
#define STARTGAME_RESPONSE "222"
#define GETROOMSTATE_RESPONSE "223"
#define NON_CODE_CHAR 3
#define STATUS_SUCCESS 0
#define STATUS_ROOM_ISSUE 1

RoomAdminRequestHandler::RoomAdminRequestHandler(LoggedUser user, RoomManager& manager, GameManager& gameManager, std::shared_ptr<Room> room, RequestHandlerFactory* handlerFactory) : m_user(user), m_roomManager(manager), m_gameManager(gameManager), m_room(room), m_handlerFactory(handlerFactory)
{}


bool RoomAdminRequestHandler::isRequestRelevant(const Request& request)
{
	if (!request.buffer.rfind(CLOSEROOM_CODE, 0) || !request.buffer.rfind(STARTGAME_CODE, 0) || !request.buffer.rfind(GETROOMSTATE_CODE, 0))
	{
		return true;
	}
	return false;
}



RequestResult RoomAdminRequestHandler::handleRequest(const Request& request)
{
	if (!request.buffer.rfind(CLOSEROOM_CODE, 0))
	{
		return closeRoom(request);
	}
	if (!request.buffer.rfind(STARTGAME_CODE, 0))
	{
		return startGame(request);
	}

	return getRoomState(request);
}


RequestResult RoomAdminRequestHandler::closeRoom(const Request& request)
{
	RequestResult resp;
	m_roomManager.deleteRoom(m_room);
	m_room->closeRoom();
	CloseRoomResponse success;
	success.status = STATUS_SUCCESS;
	std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
	msg = CLOSEROOM_RESPONSE + msg;
	resp.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	resp.response = msg;
	return resp;
}


RequestResult RoomAdminRequestHandler::startGame(const Request& request)
{
	RequestResult resp;
	m_room->setGameAsStarted(m_gameManager.createGame(*m_room));
	m_roomManager.deleteRoom(m_room);
	StartGameResponse success;
	success.status = STATUS_SUCCESS;
	std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
	msg = STARTGAME_RESPONSE + msg;
	resp.newHandler = m_handlerFactory->createGameRequestHandler(m_user, m_room->getGame());
	resp.response = msg;
	return resp;
}


RequestResult RoomAdminRequestHandler::getRoomState(const Request& request)
{
	RequestResult resp;
	GetRoomStateResponse success;
	success.status = STATUS_SUCCESS;
	success.room = *m_room;
	std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
	msg = GETROOMSTATE_RESPONSE + msg;
	resp.newHandler = nullptr;
	resp.response = msg;
	return resp;
}