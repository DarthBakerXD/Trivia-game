#include "Room.h"

Room::Room()
{}

Room::Room(RoomData metadata)
{
	m_metadata = metadata;
	m_game = nullptr;
}

void Room::addUser(LoggedUser user)
{
	m_users.push_back(user);
}


void Room::removeUser(LoggedUser& user)
{
	std::vector<LoggedUser>::iterator it;
	for (it = m_users.begin(); it != m_users.end(); it++)
	{
		if (it->getUsername() == user.getUsername())
		{
			m_users.erase(it);
			break;
		}
	}
}


std::vector<LoggedUser> Room::getAllUsers() const
{
	return m_users;
}

RoomData Room::getMetadata() const
{
	return m_metadata;
}

void Room::closeRoom()
{
	m_metadata.isActive = -1;
}

void Room::setGameAsStarted(std::shared_ptr<Game> game)
{
	m_game = game;
	m_metadata.isActive = 1;
}

std::shared_ptr<Game> Room::getGame()
{
	return m_game;
}