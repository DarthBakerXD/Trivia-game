#include "IDatabase.h"
#include <io.h>
#include "DatabaseException.h"
#include "DBHelper.h"
#include "QuestionData.h"

#define FILE_DOESNT_EXIST -1
#define MAX_STR_LEN 1024
#define DB_NAME "triviaDB.sqlite"
#define DB_ENABLE_FOREIGN_KEYS "PRAGMA foreign_keys = ON;"
#define DB_CREATE_USER_TABLE "CREATE TABLE USERS (USERNAME TEXT PRIMARY KEY NOT NULL, PASS TEXT NOT NULL, EMAIL TEXT NOT NULL);"
#define DB_CREATE_QUESTION_TABLE "CREATE TABLE QUESTIONS (QUESTION TEXT PRIMARY KEY NOT NULL, CORRECT_ANS TEXT NOT NULL, ANS2 TEXT NOT NULL, ANS3 TEXT NOT NULL, ANS4 TEXT NOT NULL);"
#define DB_CREATE_GAME_TABLE "CREATE TABLE GAMES (GAME_ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, STATUS INTEGER NOT NULL, START_TIME INTEGER NOT NULL, END_TIME INTEGER NOT NULL);"
#define DB_CREATE_HIGHSCORE_TABLE "CREATE TABLE HIGHSCORES (SCORE INTEGER NOT NULL, USERNAME TEXT NOT NULL, FOREIGN KEY(USERNAME) REFERENCES USERS(USERNAME));"
#define DB_CREATE_STATS_TABLE "CREATE TABLE STATS (USERNAME TEXT PRIMARY KEY NOT NULL, CORRECTANS INTEGER NOT NULL, WRONGANS INTEGER NOT NULL, AVGTIME INTEGER NOT NULL, FOREIGN KEY(USERNAME) REFERENCES USERS(USERNAME));"
#define DB_CHECK_IF_USER_EXISTS "SELECT EXISTS(SELECT 1 FROM USERS WHERE USERS.USERNAME == \"%s\" AND USERS.PASS == \"%s\");"
#define DB_FETCH_HIGHSCORES "SELECT * FROM HIGHSCORES ORDER BY SCORE DESC;"
#define DB_ADD_USER "INSERT INTO USERS(USERNAME, PASS, EMAIL) VALUES (\"%s\", \"%s\", \"%s\")"
#define DB_FETCH_PLAYER_SATS "SELECT * FROM STATS WHERE STATS.USERNAME == \"%s\";"
#define DB_UPDATE_STATS "UPDATE STATS SET CORRECTANS = %d, WRONGANS = %d, AVGTIME = %d WHERE STATS.USERNAME == \"%s\";"
#define DB_NEW_STATS "INSERT INTO STATS(USERNAME, CORRECTANS, WRONGANS, AVGTIME) VALUES (\"%s\", %d, %d, %d);"
#define DB_GET_QUESTIONS "SELECT * FROM QUESTIONS;"
#define DB_NEW_QUESTION "INSERT INTO QUESTIONS (QUESTION, CORRECT_ANS, ANS2, ANS3, ANS4) VALUES (\"%s\", \"%s\", \"%s\", \"%s\", \"%s\");"
#define DB_UPDATE_HIGHSCORE "UPDATE HIGHSCORES SET SCORE = %d WHERE HIGHSCORES.USERNAME == \"%s\";"
#define DB_NEW_HIGHSCORE "INSERT INTO HIGHSCORES(SCORE, USERNAME) VALUES (%d, \"%s\");"
#define ANS_ONE_INDEX 0
#define ANS_TWO_INDEX 1
#define ANS_THREE_INDEX 2
#define ANS_FOUR_INDEX 3

IDatabase::IDatabase()
{
	int dbExists = _access(DB_NAME, 0); // Check if the database file already exists before anything else
	if (sqlite3_open(DB_NAME, &db) != SQLITE_OK)
	{
		throw DatabaseException("Failed to open database file");
	}
	if (dbExists == FILE_DOESNT_EXIST)
	{
		executeQuery(DB_ENABLE_FOREIGN_KEYS, nullptr, nullptr);
		executeQuery(DB_CREATE_USER_TABLE, nullptr, nullptr);
		executeQuery(DB_CREATE_QUESTION_TABLE, nullptr, nullptr);
		executeQuery(DB_CREATE_GAME_TABLE, nullptr, nullptr);
		executeQuery(DB_CREATE_HIGHSCORE_TABLE, nullptr, nullptr);
		executeQuery(DB_CREATE_STATS_TABLE, nullptr, nullptr);
		insertDefaultQuestions();

	}
}

void IDatabase::insertDefaultQuestions()
{
	char* query = new char[MAX_STR_LEN];
	for (auto i = DEFAULT_QUESTIONS.begin(); i != DEFAULT_QUESTIONS.end(); i++)
	{
		auto answers = i->getPossibleAnswers();
		sprintf(query, DB_NEW_QUESTION, i->getQuestion().c_str(), answers[ANS_ONE_INDEX].c_str(), answers[ANS_TWO_INDEX].c_str(), answers[ANS_THREE_INDEX].c_str(), answers[ANS_FOUR_INDEX].c_str());
		executeQuery(query, nullptr, nullptr);
	}
	delete query;
}

std::map<LoggedUser, int> IDatabase::getHighscores()
{
	std::map<LoggedUser, int> highscores;
	executeQuery(DB_FETCH_HIGHSCORES, &highscores, &convertToMap);
	return highscores;
}

void IDatabase::executeQuery(const char * query, void * valuePtr, int(*funcPtr)(void *, int, char **, char **))
{
	char* errorMessage = nullptr;
	int sqliteError = sqlite3_exec(db, query, funcPtr, valuePtr, &errorMessage);
	if (sqliteError != SQLITE_OK)
	{
		throw DatabaseException(errorMessage);
	}
}

bool IDatabase::doesUserExist(std::string username, std::string password)
{
	bool exist = false;
	char* query = new char[MAX_STR_LEN];
	sprintf(query, DB_CHECK_IF_USER_EXISTS, username.c_str(), password.c_str());
	executeQuery(query, &exist, turnCharToBool);
	delete query;
	return exist;
}

void IDatabase::createNewUser(std::string username, std::string password, std::string email)
{
	char* query = new char[MAX_STR_LEN];
	sprintf(query, DB_ADD_USER, username.c_str(), password.c_str(), email.c_str());
	executeQuery(query, nullptr, nullptr);
	sprintf(query, DB_NEW_STATS, username.c_str(), 0, 0, 0); // Create Empty Stats For The New User
	executeQuery(query, nullptr, nullptr);
	sprintf(query, DB_NEW_HIGHSCORE, 0, username.c_str());
	executeQuery(query, nullptr, nullptr);
	delete query;
}

void IDatabase::updateUserStats(const PlayerResults & stats)
{
	char* query = new char[MAX_STR_LEN];
	PlayerResults previous = getPlayerStats(stats.username);
	PlayerResults newStats;
	newStats.username = stats.username;
	newStats.correctAnswerCount = stats.correctAnswerCount + previous.correctAnswerCount;
	newStats.wrongAnswerCount = stats.wrongAnswerCount + previous.wrongAnswerCount;
	if (previous.averageAnswerTime != 0)
	{
		newStats.averageAnswerTime = (stats.averageAnswerTime + previous.averageAnswerTime) / 2;
	}
	else
	{
		newStats.averageAnswerTime = stats.averageAnswerTime;
	}
	sprintf(query, DB_UPDATE_STATS, newStats.correctAnswerCount, newStats.wrongAnswerCount, newStats.averageAnswerTime, newStats.username.c_str());
	executeQuery(query, nullptr, nullptr);
	sprintf(query, DB_UPDATE_HIGHSCORE, newStats.correctAnswerCount, newStats.username.c_str());
	executeQuery(query, nullptr, nullptr);
	delete query;
}

PlayerResults IDatabase::getPlayerStats(std::string username)
{
	char* query = new char[MAX_STR_LEN];
	PlayerResults result;
	sprintf(query, DB_FETCH_PLAYER_SATS, username.c_str());
	executeQuery(query, &result, convertToPlayerResults);
	delete query;
	return result;
}


std::vector<Question> IDatabase::getQuestions()
{
	std::vector<Question> questions;
	executeQuery(DB_GET_QUESTIONS, &questions, addToQuestions);
	return questions;
}