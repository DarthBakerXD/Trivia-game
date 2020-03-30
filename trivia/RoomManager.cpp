#include "RoomManager.h"
#include "RoomManagerException.h"

std::shared_ptr<Room> RoomManager::createRoom(LoggedUser user, RoomData metadata)
{
	for (auto i = m_rooms.begin(); i != m_rooms.end(); i++)
	{
		auto roomUsers = i->second->getAllUsers();
		if (std::find(roomUsers.begin(), roomUsers.end(), user) != roomUsers.end())
		{
			throw RoomManagerException("User Is Already In A Room!");
		}
	}
	metadata.id = id;
	metadata.isActive = 0;
	auto room = std::shared_ptr<Room>(new Room(metadata));
	room->addUser(user);
	m_rooms[id] = room;
	return m_rooms[id++];
}

std::shared_ptr<Room> RoomManager::joinRoom(int ID, LoggedUser user)
{
	for (auto i = m_rooms.begin(); i != m_rooms.end(); i++)
	{
		auto roomUsers = i->second->getAllUsers();
		if (std::find(roomUsers.begin(), roomUsers.end(), user) != roomUsers.end())
		{
			throw RoomManagerException("User Is Already In A Room!");
		}
	}
	if (getRoomState(ID) != 0)
	{
		throw RoomManagerException("Game Is Already In Progress!");
	}
	auto room = m_rooms.find(ID);
	if (room->second->getMetadata().maxPlayers == room->second->getAllUsers().size())
	{
		throw RoomManagerException("Room Is Full!");
	}
	room->second->addUser(user);
	return m_rooms[room->first];
}

void RoomManager::deleteRoom(std::shared_ptr<Room> room)
{
	for (auto i = m_rooms.begin(); i != m_rooms.end(); i++)
	{
		if (i->second->getMetadata().id == room->getMetadata().id)
		{
			m_rooms.erase(i);
			break;
		}
	}
}

unsigned int RoomManager::getRoomState(int ID)
{
	auto room = m_rooms.find(ID);
	if (room == m_rooms.end())
	{
		throw RoomManagerException("Room with that ID doesn't exist!");
	}
	return room->second->getMetadata().isActive;
}

std::map<unsigned int, std::shared_ptr<Room>> RoomManager::getRooms()
{
	return m_rooms;
}