#include "RequestHandlerFactory.h"
#include "LoginRequestHandler.h"
#include "MenuRequestHandler.h"
#include "RoomAdminRequestHandler.h"
#include "RoomMemberRequestHandler.h"
#include "GameRequestHandler.h"

RequestHandlerFactory::RequestHandlerFactory(LoginManager& loginManager, RoomManager& roomManager, HighscoreTable& highscoreTable, GameManager& gameManager, IDatabase& db) : m_loginManager(loginManager), m_roomManager(roomManager), m_highscoreTable(highscoreTable), m_gameManager(gameManager), m_database(db)
{}

LoginRequestHandler * RequestHandlerFactory::createLoginRequestHandler()
{
	return new LoginRequestHandler(m_loginManager, this);
}

MenuRequestHandler * RequestHandlerFactory::createMenuRequestHandler(LoggedUser user)
{
	return new MenuRequestHandler(user, m_roomManager, m_highscoreTable, this, m_loginManager, m_database);
}

RoomAdminRequestHandler * RequestHandlerFactory::createRoomAdminRequestHandler(LoggedUser user, std::shared_ptr<Room> room)
{
	return new RoomAdminRequestHandler(user, m_roomManager, m_gameManager, room, this);
}

RoomMemberRequestHandler * RequestHandlerFactory::createRoomMemberRequestHandler(LoggedUser user, std::shared_ptr<Room> room)
{
	return new RoomMemberRequestHandler(user, m_roomManager, room, this);
}

GameRequestHandler * RequestHandlerFactory::createGameRequestHandler(LoggedUser user, std::shared_ptr<Game> game)
{
	return new GameRequestHandler(user, m_gameManager, game, m_database, this);
}