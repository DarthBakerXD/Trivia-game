#pragma once

#include "IRequestHandler.h"
#include "Room.h"
#include "LoggedUser.h"
#include "RoomManager.h"
#include "RequestHandlerFactory.h"


class RoomAdminRequestHandler : public IRequestHandler
{

public:

	RoomAdminRequestHandler(LoggedUser user, RoomManager& manager, GameManager& gameManager, std::shared_ptr<Room> room, RequestHandlerFactory* handlerFactory);
	virtual bool isRequestRelevant(const Request& request);
	virtual RequestResult handleRequest(const Request& request);


private:

	std::shared_ptr<Room> m_room;
	LoggedUser m_user;
	RoomManager& m_roomManager;
	GameManager& m_gameManager;
	RequestHandlerFactory* m_handlerFactory;
	RequestResult closeRoom(const Request& request);
	RequestResult startGame(const Request& request);
	RequestResult getRoomState(const Request& request);

};