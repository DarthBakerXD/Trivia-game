#pragma once

#include "IRequestHandler.h"
#include "Room.h"
#include "LoggedUser.h"
#include "RoomManager.h"
#include "RequestHandlerFactory.h"


class RoomMemberRequestHandler : public IRequestHandler
{

public:

	RoomMemberRequestHandler(LoggedUser user, RoomManager& manager, std::shared_ptr<Room> room, RequestHandlerFactory* handlerFactory);
	virtual bool isRequestRelevant(const Request& request);
	virtual RequestResult handleRequest(const Request& request);


private:

	std::shared_ptr<Room> m_room;
	LoggedUser m_user;
	RoomManager& m_roomManager;
	RequestHandlerFactory* m_handlerFactory;
	RequestResult leaveRoom(const Request& request);
	RequestResult getRoomState(const Request& request);

};