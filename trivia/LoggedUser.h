#pragma once
#include <string>

class LoggedUser
{
public:
	LoggedUser();
	LoggedUser(std::string username);
	std::string getUsername() const;
	void setUsername(std::string username);
	bool operator<(const LoggedUser& other) const;
	bool operator==(const LoggedUser& other) const;
private:
	std::string m_username;
};
