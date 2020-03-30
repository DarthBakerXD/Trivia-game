#pragma once
#include <exception>
#include <string>

class LoginManagerException : public std::exception
{
public:
	LoginManagerException(std::string error)
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
