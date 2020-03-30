#pragma once
#include "IRequestHandler.h"
#include "LoggedUser.h"
#include "RequestHandlerFactory.h"
#include "RoomManager.h"
#include "HighscoreTable.h"

class MenuRequestHandler : public IRequestHandler
{
public:
	MenuRequestHandler(LoggedUser user, RoomManager& manager, HighscoreTable& highscoreTable, RequestHandlerFactory* handlerFactory, LoginManager& lManager, IDatabase& db);
	virtual bool isRequestRelevant(const Request& request);
	virtual RequestResult handleRequest(const Request& request);
	RequestResult signout(const Request& request);
	RequestResult getRooms(const Request& request);
	RequestResult getPlayersInRoom(const Request& request);
	RequestResult getHighscores(const Request& request);
	RequestResult joinRoom(const Request& request);
	RequestResult createRoom(const Request& request);
	RequestResult getStats(const Request& request);
protected:
	LoggedUser m_user;
	RoomManager& m_roomManager;
	HighscoreTable& m_highscoreTable;
	RequestHandlerFactory* m_handlerFactory;
	LoginManager& m_loginManager;
	IDatabase& m_database;
};