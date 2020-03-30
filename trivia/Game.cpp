#include "Game.h"
#include <random>
#include <ctime>


Game::Game(std::vector<LoggedUser> players, std::vector<Question> questions)
{
	m_questions = questions;

	for (auto i = players.begin(); i != players.end(); i++)
	{
		m_players[*i] = GameData();
		m_players[*i].currentQuestion = m_questions[0];
	}
}


Question Game::getQuestionForUser(LoggedUser user)
{
	auto answers = m_players[user].currentQuestion.getPossibleAnswers();
	auto question = m_players[user].currentQuestion.getQuestion();
	std::default_random_engine randomEngine(std::time(0));
	std::shuffle(answers.begin(), answers.end(), randomEngine); // Randomly Shuffle The Questions, Seed Is Set in main.cpp
	return Question(question, answers);
}


std::string Game::submitAnswer(LoggedUser player, std::string answer, unsigned int elapsedTime)
{
	auto totalTime	= m_players[player].averageAnswerTime * (m_players[player].answerCount++); // Take The Previous Amount of elapsed time, multiply it by the amount of answers, add to it the new time it took to answer this question, then divide by the new amount of answers.
	m_players[player].averageAnswerTime = (totalTime + elapsedTime) / m_players[player].answerCount;
	auto correctAns = m_players[player].currentQuestion.getCorrectAnswer();
	if (answer == correctAns)
	{
		m_players[player].correctAnswerCount++;
	}
	else
	{
		m_players[player].wrongAnswerCount++;
	}
	auto currentAns = std::find(m_questions.begin(), m_questions.end(), m_players[player].currentQuestion);
	currentAns++;
	if (currentAns != m_questions.end()) // If we haven't reached the end
	{
		m_players[player].currentQuestion = *currentAns;// Advance To Next Question
	}
	return correctAns;
}


void Game::removePlayer(LoggedUser player)
{
	m_players.erase(player);
}


std::map<LoggedUser, GameData> Game::getPlayers()
{
	return m_players;
}