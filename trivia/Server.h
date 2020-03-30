#pragma once
#include "RequestHandlerFactory.h"
#include "IDatabase.h"
#include "Communicator.h"

class Server
{
public:
	Server();
	void run();
private:
	IDatabase m_database;
	LoginManager m_loginManager;
	RoomManager m_roomManager;
	Communicator m_communicator;
	RequestHandlerFactory m_handlerFactory;
	HighscoreTable m_highscoreTable;
	GameManager m_gameManager;
};