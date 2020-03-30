#include "Communicator.h"
#include "CommunicatorException.h"
#include "LoginRequestHandler.h"
#include "Response.h"
#include "JSONHandlers.h"

#define BUFFER_SIZE 1024
#define ERROR_CODE "999"

#pragma comment(lib, "ws2_32.lib")

Communicator::Communicator(RequestHandlerFactory & factory) : m_handlerFactory(factory)
{}

std::thread Communicator::bindAndListen()
{
	return std::thread(&Communicator::mainServerListener, this); // Since we need to return a thread, bindAndListen becomes a helper function to summon the actual function that runs in a thread.
}

void Communicator::mainServerListener()
{
	WSADATA wsa_data = {};
	if (WSAStartup(MAKEWORD(2, 2), &wsa_data) != 0)
	{
		throw CommunicatorException("WSAStartup Failed");
	}
	SOCKET serverSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

	if (serverSocket == INVALID_SOCKET)
	{
		throw CommunicatorException(__FUNCTION__ " - socket");
	}
	struct sockaddr_in sa = { 0 };

	sa.sin_port = htons(SERVER_PORT); // port that server will listen for
	sa.sin_family = AF_INET;   // must be AF_INET
	sa.sin_addr.s_addr = INADDR_ANY;    // when there are few ip's for the machine. We will use always "INADDR_ANY"

										// Connects between the socket and the configuration (port and etc..)
	if (bind(serverSocket, (struct sockaddr*)&sa, sizeof(sa)) == SOCKET_ERROR)
	{
		throw CommunicatorException(__FUNCTION__ " - bind");
	}
	// Start listening for incoming requests of clients
	if (listen(serverSocket, SOMAXCONN) == SOCKET_ERROR)
	{
		throw CommunicatorException(__FUNCTION__ " - listen");
	}
	std::cout << "Listening on port " << SERVER_PORT << std::endl;
	while (true)
	{

		std::cout << "Waiting for client connection request" << std::endl;

		SOCKET client_socket = accept(serverSocket, NULL, NULL);

		if (client_socket == INVALID_SOCKET)
		{
			throw CommunicatorException(__FUNCTION__);
		}

		std::cout << "Client accepted. Creating Handler.." << std::endl;
		m_clients[client_socket] = m_handlerFactory.createLoginRequestHandler();
		std::thread(&Communicator::startThreadForNewClient, this, client_socket).detach();
	}
}

void Communicator::handleRequest(SOCKET client, Request rec)
{
	RequestResult result = m_clients[client]->handleRequest(rec);
	if (result.newHandler != nullptr)
	{
		m_clients[client] = result.newHandler;
	}
	std::cout << "Sending " << result.response.length() << " Bytes of Data To Client" << std::endl;
	int sendResult = send(client, result.response.c_str(), result.response.length(), 0);
	if (sendResult == SOCKET_ERROR)
	{
		std::cout << __FUNCTION__ " - SOCKET_ERROR In Response To Send" << std::endl;
	}
}


void Communicator::startThreadForNewClient(SOCKET client)
{
	char* msg = new char[BUFFER_SIZE];
	int id = 0;
	while (true)
	{
		int result = recv(client, msg, BUFFER_SIZE, 0);
		if (result == SOCKET_ERROR)
		{
			m_clients.erase(client);
			std::cout << __FUNCTION__ " - SOCKET_ERROR In Response To Recv" << std::endl;
			break; // Socket Must Be Closed
		}
		Request incoming;
		incoming.id = id++;
		incoming.receivalTime = CTime::GetCurrentTime();
		incoming.buffer = std::string(msg, result);
		if (m_clients[client]->isRequestRelevant(incoming))
		{
			handleRequest(client, incoming);
		}
		else
		{
			ErrorResponse err;
			err.message = "Invalid Request!";
			std::string output = JsonResponsePacketSerializer::serializeResponse(err);
			output = ERROR_CODE + output;
			int sendResult = send(client, output.c_str(), output.length(), 0);
			if (sendResult == SOCKET_ERROR)
			{
				m_clients.erase(client);
				std::cout << __FUNCTION__ " - SOCKET_ERROR In Response To Send" << std::endl;
				break;
			}
		}
	}
}