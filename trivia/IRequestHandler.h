#pragma once
#include <string>
#include "Request.h"

class IRequestHandler
{
public:
	virtual bool isRequestRelevant(const Request& request) = 0;
	virtual RequestResult handleRequest(const Request& request) = 0;
};