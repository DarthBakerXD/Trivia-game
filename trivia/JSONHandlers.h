#pragma once
#include <vector>
#include "Response.h"
#include "Request.h"
#include "json.hpp"

using json = nlohmann::json;

struct JsonResponsePacketSerializer
{
	static std::string serializeResponse(const ErrorResponse& response);
	static std::string serializeResponse(const LoginResponse& response);
	static std::string serializeResponse(const SignupResponse& response);
	static std::string serializeResponse(const LogoutResponse& response);
	static std::string serializeResponse(const GetRoomsResponse& response);
	static std::string serializeResponse(const GetPlayersInRoomResponse& response);
	static std::string serializeResponse(const JoinRoomResponse& response);
	static std::string serializeResponse(const CreateRoomResponse& response);
	static std::string serializeResponse(const HighscoreResponse& response);
	static std::string serializeResponse(const CloseRoomResponse& response);
	static std::string serializeResponse(const StartGameResponse& response);
	static std::string serializeResponse(const GetRoomStateResponse& response);
	static std::string serializeResponse(const LeaveRoomResponse& response);
	static std::string serializeResponse(const GetQuestionResponse& response);
	static std::string serializeResponse(const SubmitAnswerResponse& response);
	static std::string serializeResponse(const GetGameResultsResponse& response);
	static std::string serializeResponse(const GetStatsResponse& response);
};

struct JsonRequestPacketDeserializer
{
	static LoginRequest deserializeLoginRequest(const std::string& buffer);
	static SignupRequest deserializeSignupRequest(const std::string& buffer);
	static GetPlayersInRoomRequest deserializeGetPlayerRequest(const std::string& buffer);
	static JoinRoomRequest deserializeJoinRoomRequest(const std::string& buffer);
	static CreateRoomRequest deserializeCreateRoomRequest(const std::string& buffer);
	static SubmitAnswerRequest deserializeSubmitAnswerRequest(const std::string& buffer);
};

void to_json(json& j, const ErrorResponse& p);
void to_json(json& j, const LoginResponse& p);
void from_json(const json& j, LoginResponse& p);
void to_json(json& j, const SignupResponse& p);
void from_json(const json& j, SignupResponse& p);
void to_json(json& j, const LogoutResponse& p);
void from_json(const json& j, LogoutResponse& p);
void to_json(json& j, const GetRoomsResponse& p);
void from_json(const json& j, GetRoomsResponse& p);
void to_json(json& j, const GetPlayersInRoomResponse& p);
void from_json(const json& j, GetPlayersInRoomResponse& p);
void to_json(json& j, const JoinRoomResponse& p);
void from_json(const json& j, JoinRoomResponse& p);
void to_json(json& j, const CreateRoomResponse& p);
void from_json(const json& j, CreateRoomResponse& p);
void to_json(json& j, const HighscoreResponse& p);
void from_json(const json& j, HighscoreResponse& p);
void to_json(json& j, const CloseRoomResponse& p);
void from_json(const json& j, CloseRoomResponse& p);
void to_json(json& j, const StartGameResponse& p);
void from_json(const json& j, StartGameResponse& p);
void to_json(json& j, const GetRoomStateResponse& p);
void from_json(const json& j, GetRoomStateResponse& p);
void to_json(json& j, const LeaveRoomResponse& p);
void from_json(const json& j, LeaveRoomResponse& p);
void to_json(json& j, const GetQuestionResponse& p);
void from_json(const json& j, GetQuestionResponse& p);
void to_json(json& j, const SubmitAnswerResponse& p);
void from_json(const json& j, SubmitAnswerResponse& p);
void to_json(json& j, const GetGameResultsResponse& p);
void from_json(const json& j, GetGameResultsResponse& p);
void to_json(json& j, const GetStatsResponse& p);
void to_json(json& j, const LoginRequest& p);
void from_json(const json& j, LoginRequest& p);
void to_json(json& j, const SignupRequest& p);
void from_json(const json& j, SignupRequest& p);
void to_json(json& j, const GetPlayersInRoomRequest& p);
void from_json(const json& j, GetPlayersInRoomRequest& p);
void to_json(json& j, const JoinRoomRequest& p);
void from_json(const json& j, JoinRoomRequest& p);
void to_json(json& j, const CreateRoomRequest& p);
void from_json(const json& j, CreateRoomRequest& p);
void to_json(json& j, const SubmitAnswerRequest& p);
void from_json(const json& j, SubmitAnswerRequest& p);

void to_json(json& j, const LoggedUser& p);
void from_json(const json& j, LoggedUser& p);
void to_json(json& j, const Room& p);
void to_json(json& j, const RoomData& p);
void to_json(json& j, const std::map<unsigned int, std::shared_ptr<Room>>& p);
void to_json(json & j, const Question & p);
void to_json(json & j, const PlayerResults & p);