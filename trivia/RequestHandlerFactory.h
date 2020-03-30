#pragma once
#include "LoginManager.h"
#include "RoomManager.h"
#include "HighscoreTable.h"
#include "GameManager.h"

class LoginRequestHandler; // Forward Declaration To Avoid Recursive Inclusion
class MenuRequestHandler;
class RoomAdminRequestHandler;
class RoomMemberRequestHandler;
class GameRequestHandler;

class RequestHandlerFactory
{
public:
	RequestHandlerFactory(LoginManager& loginManager, RoomManager& roomManager, HighscoreTable& highscoreTable, GameManager& gameManager, IDatabase& db);
	LoginRequestHandler* createLoginRequestHandler();
	MenuRequestHandler* createMenuRequestHandler(LoggedUser user);
	RoomAdminRequestHandler* createRoomAdminRequestHandler(LoggedUser user, std::shared_ptr<Room> room);
	RoomMemberRequestHandler* createRoomMemberRequestHandler(LoggedUser user, std::shared_ptr<Room> room);
	GameRequestHandler* createGameRequestHandler(LoggedUser user, std::shared_ptr<Game> game);

private:
	LoginManager& m_loginManager;
	RoomManager& m_roomManager;
	HighscoreTable& m_highscoreTable;
	GameManager& m_gameManager;
	IDatabase& m_database;

};