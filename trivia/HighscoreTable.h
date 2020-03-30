#pragma once
#include "IDatabase.h"

class HighscoreTable
{
public:
	HighscoreTable(IDatabase& db);
	std::map<LoggedUser, int> getHighscores();

private:

	IDatabase& m_database;

};
