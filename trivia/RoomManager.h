#pragma once
#include <map>
#include "Room.h"

class RoomManager
{

public:

	std::shared_ptr<Room> createRoom(LoggedUser user, RoomData metadata);
	std::shared_ptr<Room> joinRoom(int ID, LoggedUser user);
	void deleteRoom(std::shared_ptr<Room> room);
	unsigned int getRoomState(int ID);
	std::map<unsigned int, std::shared_ptr<Room>> getRooms();

private:
	int id;
	std::map<unsigned int, std::shared_ptr<Room>> m_rooms;

};
