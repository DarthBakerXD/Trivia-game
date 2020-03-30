#include "DBHelper.h"
#include <iostream>
#include <map>
#include <vector>
#include "LoggedUser.h"
#include "PlayerResults.h"
#include "Question.h"

#define SCORE_INDEX 0
#define USER_INDEX 1
#define STATS_USER_INDEX 0
#define CORRECT_ANS_INDEX 1
#define WRONG_ANS_INDEX 2
#define AVG_TIME_INDEX 3
#define QUESTION_INDEX 0
#define ANSWER_ONE_INDEX 1
#define ANSWER_TWO_INDEX 2
#define ANSWER_THREE_INDEX 3
#define ANSWER_FOUR_INDEX 4

int turnCharToBool(void * data, int, char ** argv, char **)
{
	bool* result = (bool*)data;
	*result = std::atoi(argv[0]);
	return 0;
}

int convertToMap(void * data, int, char ** argv, char **)
{
	std::map<LoggedUser, int>* output = (std::map<LoggedUser, int>*)data;
	output->insert(std::pair<LoggedUser, int>(LoggedUser(argv[USER_INDEX]), std::atoi(argv[SCORE_INDEX]))); // Insert didn't want to take the two parameters alone
	return 0;
}

int convertToPlayerResults(void * data, int, char ** argv, char **)
{
	PlayerResults* output = (PlayerResults*)data;
	output->username = argv[STATS_USER_INDEX];
	output->correctAnswerCount = std::atoi(argv[CORRECT_ANS_INDEX]);
	output->wrongAnswerCount = std::atoi(argv[WRONG_ANS_INDEX]);
	output->averageAnswerTime = std::atoi(argv[AVG_TIME_INDEX]);
	return 0;
}

int addToQuestions(void * data, int, char ** argv, char **)
{
	std::vector<Question>* output = (std::vector<Question>*)data;
	std::string question = argv[QUESTION_INDEX];
	std::vector<std::string> answers = { argv[ANSWER_ONE_INDEX], argv[ANSWER_TWO_INDEX], argv[ANSWER_THREE_INDEX], argv[ANSWER_FOUR_INDEX] };
	output->push_back(Question(question, answers));
	return 0;
}