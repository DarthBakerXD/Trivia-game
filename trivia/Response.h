#pragma once
#include <string>
#include <vector>
#include <map>
#include "Room.h"
#include "LoggedUser.h"
#include "PlayerResults.h"
#include "Question.h"

struct ErrorResponse
{
	std::string message;
};

struct LoginResponse
{
	unsigned int status;
};

struct SignupResponse
{
	unsigned int status;
};

struct LogoutResponse
{
	unsigned int status;
};

struct GetRoomsResponse
{
	unsigned int status;
	std::map<unsigned int, std::shared_ptr<Room>> rooms;
};

struct GetPlayersInRoomResponse
{
	std::vector<LoggedUser> players;
};

struct HighscoreResponse
{
	unsigned int status;
	std::map<LoggedUser, int> highscores;
};

struct JoinRoomResponse
{
	unsigned int status;
};

struct CreateRoomResponse
{
	unsigned int status;
	unsigned int id;
};

struct CloseRoomResponse
{
	unsigned int status;
};

struct StartGameResponse
{
	unsigned int status;
};

struct GetRoomStateResponse
{
	unsigned int status;
	Room room;
};

struct LeaveRoomResponse
{
	unsigned int status;
};

struct GetQuestionResponse
{
	unsigned int status;
	Question question; // No need to split up the class into its individual members.
};

struct SubmitAnswerResponse
{
	unsigned int status;
	std::string correctAnswer; // Just return the correct answer and let the client highlight it
};

struct GetGameResultsResponse
{
	unsigned int status;
	std::vector<PlayerResults> results;
};

struct GetStatsResponse
{
	unsigned int status;
	PlayerResults stats;
};