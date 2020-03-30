#pragma once
#include <string>

struct RoomData
{
	int id;
	std::string name;
	int maxPlayers;
	unsigned int timePerQuestion;
	unsigned int numOfQuestions;
	int isActive;
};
