#pragma once
#include <vector>
#include "LoggedUser.h"
#include "RoomData.h"

class Game;

class Room
{

public:
	Room();
	Room(RoomData metadata);
	void addUser(LoggedUser user);
	void removeUser(LoggedUser& user);
	std::vector<LoggedUser> getAllUsers() const;
	RoomData getMetadata() const;
	void closeRoom();
	void setGameAsStarted(std::shared_ptr<Game> game);
	std::shared_ptr<Game> getGame();

private:

	RoomData m_metadata;
	std::vector<LoggedUser> m_users;
	std::shared_ptr<Game> m_game;
};
