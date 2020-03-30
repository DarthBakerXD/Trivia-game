#pragma once
#include <exception>
#include <string>

class RoomManagerException : public std::exception
{
public:
	RoomManagerException(std::string error)
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
