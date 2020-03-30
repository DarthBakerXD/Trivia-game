#pragma once
#include <exception>
#include <string>

class GameManagerException : public std::exception
{
public:
	GameManagerException(std::string error)
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