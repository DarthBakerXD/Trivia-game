#pragma once
#include "Question.h"

struct GameData
{
	GameData(); // Must Have ctor to work with STL containers
	Question currentQuestion;
	unsigned int correctAnswerCount;
	unsigned int wrongAnswerCount;
	unsigned int averageAnswerTime;
	unsigned int answerCount;
};