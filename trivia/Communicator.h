#pragma once
#include <map>
#include <WinSock2.h>
#include <Windows.h>
#include <exception>
#include <iostream>
#include <thread>
#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"

#define SERVER_PORT 5656

class Communicator
{
public:
	Communicator(RequestHandlerFactory& factory);
	std::thread bindAndListen();
	void handleRequest(SOCKET client, Request req);

private:

	std::map<SOCKET, IRequestHandler*> m_clients;
	RequestHandlerFactory& m_handlerFactory;
	void startThreadForNewClient(SOCKET client);
	void mainServerListener();
};