#pragma once
#include <exception>
#include <string>

class DatabaseException : public std::exception
{
public:
	DatabaseException(std::string error)
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