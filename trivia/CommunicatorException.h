#pragma once
#include <exception>

class CommunicatorException : public std::exception
{
public:
	CommunicatorException(std::string error)
	{
		errorMessage = error;
	}
	const char* what()
	{
		return errorMessage.c_str();
	}
protected:
	std::string errorMessage;
};