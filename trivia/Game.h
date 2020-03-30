#pragma once

#include "Question.h"
#include "GameData.h"
#include "LoggedUser.h"
#include "Room.h"
#include <vector>
#include <map>



class Game
{
public:

	Game(std::vector<LoggedUser>, std::vector<Question>);
	Question getQuestionForUser(LoggedUser);
	std::string submitAnswer(LoggedUser player, std::string Answer, unsigned int elapsedTime);
	void removePlayer(LoggedUser player);
	std::map<LoggedUser, GameData> getPlayers();

private:

	std::vector<Question> m_questions;
	std::map<LoggedUser, GameData> m_players;

};
