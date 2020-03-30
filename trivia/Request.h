#pragma once
#include <string>
#include <atltime.h>

class IRequestHandler;

struct Request
{
	unsigned int id;
	CTime receivalTime;
	std::string buffer;
};

struct RequestResult
{
	std::string response;
	IRequestHandler* newHandler;
};

struct LoginRequest
{
	std::string username;
	std::string password;
};

struct SignupRequest
{
	std::string username;
	std::string password;
	std::string email;
};

struct GetPlayersInRoomRequest
{
	unsigned int roomId;
};

struct JoinRoomRequest
{
	unsigned int roomId;
};

struct CreateRoomRequest
{
	std::string roomName;
	unsigned int maxUsers;
	unsigned int questionCount;
	unsigned int answerTimeout;
};

struct SubmitAnswerRequest
{
	std::string answer; // Much more logical than the answer being represented by an ID.
	unsigned int timeUntilResponse; // Client keeps track of elapsed time until answer by Stopwatch, and then sends it to server in seconds.
};