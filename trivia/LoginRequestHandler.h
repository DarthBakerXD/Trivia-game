#pragma once
#include "IRequestHandler.h"
#include "LoginManager.h"
#include "RequestHandlerFactory.h"

class LoginRequestHandler : public IRequestHandler
{
public:
	LoginRequestHandler(LoginManager& manager, RequestHandlerFactory* factory);
	virtual bool isRequestRelevant(const Request& request);
	virtual RequestResult handleRequest(const Request& request);
	RequestResult login(const Request& request);
	RequestResult signup(const Request& request);
protected:
	LoginManager& m_loginManager;
	RequestHandlerFactory* m_RequestHandlerFactory;
};