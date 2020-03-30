#include "RoomMemberRequestHandler.h"
#include "LoginRequestHandler.h"
#include "DatabaseException.h"
#include "RoomManagerException.h"
#include "JSONHandlers.h"
#include "MenuRequestHandler.h"
#include "GameRequestHandler.h"

#define LEAVEROOM_CODE "124"
#define GETROOMSTATE_CODE "123"
#define LEAVEROOM_RESPONSE "224"
#define GETROOMSTATE_RESPONSE "223"
#define NON_CODE_CHAR 3
#define STATUS_SUCCESS 0
#define STATUS_ROOM_ISSUE 1

RoomMemberRequestHandler::RoomMemberRequestHandler(LoggedUser user, RoomManager& manager, std::shared_ptr<Room> room, RequestHandlerFactory* handlerFactory) : m_user(user), m_roomManager(manager), m_room(room), m_handlerFactory(handlerFactory)
{}


bool RoomMemberRequestHandler::isRequestRelevant(const Request& request)
{
	if (!request.buffer.rfind(LEAVEROOM_CODE, 0) || !request.buffer.rfind(GETROOMSTATE_CODE, 0))
	{
		return true;
	}
	return false;
}



RequestResult RoomMemberRequestHandler::handleRequest(const Request& request)
{
	if (!request.buffer.rfind(LEAVEROOM_CODE, 0))
	{
		return leaveRoom(request);
	}

	return getRoomState(request);
}


RequestResult RoomMemberRequestHandler::leaveRoom(const Request& request)
{
	RequestResult resp;
	m_room->removeUser(m_user);
	LeaveRoomResponse success;
	success.status = STATUS_SUCCESS;
	std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
	msg = LEAVEROOM_RESPONSE + msg;
	resp.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	resp.response = msg;
	return resp;
}


RequestResult RoomMemberRequestHandler::getRoomState(const Request& request)
{
	RequestResult resp;
	GetRoomStateResponse success;
	success.status = STATUS_SUCCESS;
	success.room = *m_room;
	std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
	msg = GETROOMSTATE_RESPONSE + msg;
	if (m_room->getMetadata().isActive == 1) // Game Created
	{
		resp.newHandler = m_handlerFactory->createGameRequestHandler(m_user, m_room->getGame());
	}
	else
	{
		resp.newHandler = nullptr;
	}
	resp.response = msg;
	return resp;
}