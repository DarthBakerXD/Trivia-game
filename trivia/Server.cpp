#include "Server.h"
#include <thread>
#include "HighscoreTable.h"

Server::Server() : m_highscoreTable(m_database), m_handlerFactory(m_loginManager, m_roomManager, m_highscoreTable, m_gameManager, m_database), m_communicator(m_handlerFactory)
{}

void Server::run()
{
	try
	{
		std::cout << "Starting Magshitrivia server with " << m_database.getQuestions().size() << " questions in database!" << std::endl;
		std::thread serverSocketThread = m_communicator.bindAndListen(); // Start the main listening socket on a seperate thread, as it runs forever.
		serverSocketThread.join();
	}

	catch (std::exception& e)
	{
		std::cout << "Error occured: " << e.what() << std::endl;
	}
}