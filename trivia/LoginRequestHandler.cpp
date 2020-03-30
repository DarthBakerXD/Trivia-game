#include "LoginRequestHandler.h"
#include "MenuRequestHandler.h"
#include "JSONHandlers.h"
#include "DatabaseException.h"
#include "LoginManagerException.h"

#define NON_CODE_CHAR 3
#define LOGIN_CODE "101"
#define SIGNUP_CODE "102"
#define LOGIN_RESPONSE "201"
#define SIGNUP_RESPONSE "202"
#define STATUS_SUCCESS 0
#define STATUS_DATABASE_ISSUE 1
#define STATUS_LOGIN_ISSUE 2

LoginRequestHandler::LoginRequestHandler(LoginManager & manager, RequestHandlerFactory * factory) : m_loginManager(manager), m_RequestHandlerFactory(factory)
{}

bool LoginRequestHandler::isRequestRelevant(const Request & request)
{
	if (!request.buffer.rfind(LOGIN_CODE, 0) || !request.buffer.rfind(SIGNUP_CODE, 0)) // Check if the request is login or signup
	{
		return true;
	}
	return false;
}

RequestResult LoginRequestHandler::handleRequest(const Request & request)
{
	if (!request.buffer.rfind(LOGIN_CODE, 0))
	{
		return login(request);
	}
	return signup(request); // We already know the request is one of these, no need to check again if we know it's not login
}

RequestResult LoginRequestHandler::login(const Request & request)
{
	RequestResult resp;
	std::string serializedRequest = request.buffer.substr(NON_CODE_CHAR);
	LoginRequest req = JsonRequestPacketDeserializer::deserializeLoginRequest(serializedRequest);
	try
	{
		m_loginManager.login(req.username, req.password);
		LoginResponse success;
		success.status = 0;
		std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
		msg = LOGIN_RESPONSE + msg; // Put the code in front of the serialized JSON
		resp.newHandler = m_RequestHandlerFactory->createMenuRequestHandler(LoggedUser(req.username));
		resp.response = msg;
		return resp;
	}
	catch (DatabaseException&)
	{
		RequestResult resp;
		LoginResponse error;
		error.status = STATUS_DATABASE_ISSUE;
		std::string msg = JsonResponsePacketSerializer::serializeResponse(error);
		msg = LOGIN_RESPONSE + msg; // Put the code in front of the serialized JSON
		resp.newHandler = nullptr;
		resp.response = msg;
		return resp;
	}
	catch (LoginManagerException&)
	{
		RequestResult resp;
		LoginResponse error;
		error.status = STATUS_LOGIN_ISSUE;
		std::string msg = JsonResponsePacketSerializer::serializeResponse(error);
		msg = LOGIN_RESPONSE + msg; // Put the code in front of the serialized JSON
		resp.newHandler = nullptr;
		resp.response = msg;
		return resp;
	}
}

RequestResult LoginRequestHandler::signup(const Request & request)
{
	RequestResult resp;
	std::string serializedRequest = request.buffer.substr(NON_CODE_CHAR);
	SignupRequest req = JsonRequestPacketDeserializer::deserializeSignupRequest(serializedRequest);
	try
	{
		m_loginManager.signup(req.username, req.password, req.email);
		SignupResponse success;
		success.status = 0;
		std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
		msg = SIGNUP_RESPONSE + msg; // Put the code in front of the serialized JSON
		resp.newHandler = m_RequestHandlerFactory->createMenuRequestHandler(LoggedUser(req.username));
		resp.response = msg;
		return resp;
	}
	catch (DatabaseException&)
	{
		RequestResult resp;
		SignupResponse error;
		error.status = STATUS_DATABASE_ISSUE;
		std::string msg = JsonResponsePacketSerializer::serializeResponse(error);
		msg = SIGNUP_RESPONSE + msg; // Put the code in front of the serialized JSON
		resp.newHandler = nullptr;
		resp.response = msg;
		return resp;
	}
	catch (LoginManagerException&)
	{
		RequestResult resp;
		SignupResponse error;
		error.status = STATUS_LOGIN_ISSUE;
		std::string msg = JsonResponsePacketSerializer::serializeResponse(error);
		msg = SIGNUP_RESPONSE + msg; // Put the code in front of the serialized JSON
		resp.newHandler = nullptr;
		resp.response = msg;
		return resp;
	}
}