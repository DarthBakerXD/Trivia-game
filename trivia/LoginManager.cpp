#include "LoginManager.h"
#include "LoginManagerException.h"

void LoginManager::signup(std::string username, std::string password, std::string email)
{
	if (m_database.doesUserExist(username, password))
	{
		throw LoginManagerException("User Already Exists!");
	}
	m_database.createNewUser(username, password, email);
}


void LoginManager::login(std::string username, std::string password)
{
	if (!m_database.doesUserExist(username, password))
	{
		throw LoginManagerException("User Does Not Exist!");
	}
	if (std::find(m_loggedUsers.begin(), m_loggedUsers.end(), username) != m_loggedUsers.end())
	{
		throw LoginManagerException("User Is Already Logged In!");
	}
	m_loggedUsers.push_back(LoggedUser(username));
}


void LoginManager::logout(LoggedUser user)
{
	auto loggedUser = std::find(m_loggedUsers.begin(), m_loggedUsers.end(), user);
	if (loggedUser != m_loggedUsers.end()) // No Big Deal If The User That's Logging Out Doesn't Exist..
	{
		m_loggedUsers.erase(loggedUser);
	}
}