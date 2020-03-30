#pragma once
#include <string>
#include <map>
#include <list>
#include <vector>
#include "sqlite3.h"
#include "Question.h"
#include "LoggedUser.h"
#include "PlayerResults.h"

class IDatabase
{
public:
	IDatabase();
	std::map<LoggedUser, int> getHighscores();
	bool doesUserExist(std::string username, std::string password);
	void createNewUser(std::string username, std::string password, std::string email);
	void updateUserStats(const PlayerResults& stats);
	PlayerResults getPlayerStats(std::string username);
	std::vector<Question> getQuestions();	// Don't change the vector to list!

protected:
	sqlite3* db;
	void executeQuery(const char* query, void* valuePtr, int(*funcPtr)(void*, int, char**, char**));
	void insertDefaultQuestions();
};