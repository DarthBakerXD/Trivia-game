#include "GameManager.h"
#include "GameManagerException.h"
#include <algorithm>
#include <random>
#include <ctime>


std::shared_ptr<Game> GameManager::createGame(Room room)
{
	for (auto i = m_games.begin(); i != m_games.end(); i++)
	{
		auto gamePlayers = (*i)->getPlayers();
		std::vector<LoggedUser> players;
		std::transform(gamePlayers.begin(), gamePlayers.end(), std::back_inserter(players), [](const std::map<LoggedUser, GameData>::value_type &pair) {return pair.first; }); // Insert all the keys into a vector of their own using std::transform and a lambda function

		if (players == room.getAllUsers())
		{
			throw GameManagerException("Game already exists for this room!");
		}
	}
	auto questions = m_database.getQuestions();
	std::default_random_engine randomEngine(std::time(0));
	std::shuffle(questions.begin(), questions.end(), randomEngine);
	auto game = std::shared_ptr<Game>(new Game(room.getAllUsers(), questions));
	m_games.push_back(game);
	return game;
}



void GameManager::deleteGame(std::shared_ptr<Game> game)
{
	m_games.erase(std::find(m_games.begin(), m_games.end(), game));
}