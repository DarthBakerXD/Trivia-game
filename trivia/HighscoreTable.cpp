#include "HighscoreTable.h"

HighscoreTable::HighscoreTable(IDatabase & db) : m_database(db)
{}

std::map<LoggedUser, int> HighscoreTable::getHighscores()
{
	return m_database.getHighscores();
}