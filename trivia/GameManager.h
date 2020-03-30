#pragma once

#include "Room.h"
#include "IDatabase.h"
#include "Game.h"
#include <vector>



class GameManager
{
public:

	std::shared_ptr<Game> createGame(Room room);
	void deleteGame(std::shared_ptr<Game> game);

private:

	IDatabase m_database;
	std::vector<std::shared_ptr<Game>> m_games;

};