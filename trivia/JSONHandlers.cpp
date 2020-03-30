#include "JSONHandlers.h"
#include <sstream>
#include <iostream>

std::string JsonResponsePacketSerializer::serializeResponse(const ErrorResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const LoginResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const SignupResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const LogoutResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const GetRoomsResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const GetPlayersInRoomResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const JoinRoomResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const CreateRoomResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const HighscoreResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const CloseRoomResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const StartGameResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const GetRoomStateResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const LeaveRoomResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const GetQuestionResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const SubmitAnswerResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const GetGameResultsResponse & response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

std::string JsonResponsePacketSerializer::serializeResponse(const GetStatsResponse& response)
{
	json jsonResponse = response;
	auto serializedResponse = json::to_msgpack(jsonResponse);
	std::ostringstream vectorToStringStream;
	std::copy(serializedResponse.begin(), serializedResponse.end(), std::ostream_iterator<uint8_t>(vectorToStringStream));
	return vectorToStringStream.str();
}

LoginRequest JsonRequestPacketDeserializer::deserializeLoginRequest(const std::string & buffer)
{
	std::vector<uint8_t> bufferVector(buffer.begin(), buffer.end());
	return json::from_msgpack(bufferVector);
}

SignupRequest JsonRequestPacketDeserializer::deserializeSignupRequest(const std::string & buffer)
{
	std::vector<uint8_t> bufferVector(buffer.begin(), buffer.end());
	return json::from_msgpack(bufferVector);
}

GetPlayersInRoomRequest JsonRequestPacketDeserializer::deserializeGetPlayerRequest(const std::string & buffer)
{
	std::vector<uint8_t> bufferVector(buffer.begin(), buffer.end());
	return json::from_msgpack(bufferVector);
}
 
JoinRoomRequest JsonRequestPacketDeserializer::deserializeJoinRoomRequest(const std::string & buffer)
{
	std::vector<uint8_t> bufferVector(buffer.begin(), buffer.end());
	return json::from_msgpack(bufferVector);
}

CreateRoomRequest JsonRequestPacketDeserializer::deserializeCreateRoomRequest(const std::string & buffer)
{
	std::vector<uint8_t> bufferVector(buffer.begin(), buffer.end());
	return json::from_msgpack(bufferVector);
}

SubmitAnswerRequest JsonRequestPacketDeserializer::deserializeSubmitAnswerRequest(const std::string & buffer)
{
	std::vector<uint8_t> bufferVector(buffer.begin(), buffer.end());
	return json::from_msgpack(bufferVector);
}

#pragma region ArbitaryConversion
void to_json(json & j, const ErrorResponse & p)
{
	j = json{ { "message", p.message } };
}

void to_json(json & j, const LoginResponse & p)
{
	j = json{ {"status", p.status} };
}

void from_json(const json & j, LoginResponse & p)
{
	j.at("status").get_to(p.status);
}

void to_json(json & j, const SignupResponse & p)
{
	j = json{ { "status", p.status } };
}

void from_json(const json & j, SignupResponse & p)
{
	j.at("status").get_to(p.status);
}

void to_json(json & j, const LogoutResponse & p)
{
	j = json{ { "status", p.status } };
}

void from_json(const json & j, LogoutResponse & p)
{
	j.at("status").get_to(p.status);
}

void to_json(json & j, const GetRoomsResponse & p)
{
	j = json{ { "status", p.status } , {"rooms", p.rooms} };
}

void from_json(const json & j, GetRoomsResponse & p)
{
	j.at("status").get_to(p.status);
}

void to_json(json & j, const GetPlayersInRoomResponse & p)
{
	j = json{ { "players", p.players } };
}

void from_json(const json & j, GetPlayersInRoomResponse & p)
{
	j.at("players").get_to(p.players);
}

void to_json(json & j, const JoinRoomResponse & p)
{
	j = json{ { "status", p.status } };
}

void from_json(const json & j, JoinRoomResponse & p)
{
	j.at("status").get_to(p.status);
}

void to_json(json & j, const CreateRoomResponse & p)
{
	j = json{ { "status", p.status }, {"id", p.id} };
}

void from_json(const json & j, CreateRoomResponse & p)
{
	j.at("status").get_to(p.status);
	j.at("id").get_to(p.id);
}

void to_json(json & j, const HighscoreResponse & p)
{
	j = json{ { "status", p.status } , {"highscores", p.highscores} };
}

void from_json(const json & j, HighscoreResponse & p) 
{
	j.at("status").get_to(p.status);
}

void to_json(json& j, const CloseRoomResponse& p)
{
	j = json{ { "status", p.status } };
}

void from_json(const json& j, CloseRoomResponse& p)
{
	j.at("status").get_to(p.status);
}

void to_json(json& j, const StartGameResponse& p)
{
	j = json{ { "status", p.status } };
}
void from_json(const json& j, StartGameResponse& p)
{
	j.at("status").get_to(p.status);
}

void to_json(json& j, const GetRoomStateResponse& p)
{
	j = json{ { "status", p.status } , {"room", p.room} };
}

void from_json(const json& j, GetRoomStateResponse& p)
{
	j.at("status").get_to(p.status);
}

void to_json(json& j, const LeaveRoomResponse& p)
{
	j = json{ { "status", p.status } };
}

void from_json(const json& j, LeaveRoomResponse& p)
{
	j.at("status").get_to(p.status);
}

void to_json(json& j, const GetQuestionResponse& p)
{
	j = json{ { "status", p.status }, {"question", p.question } };
}

void from_json(const json& j, GetQuestionResponse& p)
{
	j.at("status").get_to(p.status);
}

void to_json(json& j, const SubmitAnswerResponse& p)
{
	j = json{ { "status", p.status }, {  "correctanswer", p.correctAnswer } };
}

void from_json(const json& j, SubmitAnswerResponse& p)
{
	j.at("status").get_to(p.status);
}

void to_json(json & j, const GetGameResultsResponse & p)
{
	j = json{ {"status", p.status}, {"results", p.results} };
}

void from_json(const json & j, GetGameResultsResponse & p)
{
	j.at("status").get_to(p.status);
}

void to_json(json& j, const GetStatsResponse& p)
{
	j = json{ {"status", p.status}, {"stats", p.stats} };
}


void to_json(json & j, const LoginRequest & p)
{
	j = json{ { "username", p.username } , { "password", p.password } };
}

void from_json(const json & j, LoginRequest & p)
{
	j.at("username").get_to(p.username);
	j.at("password").get_to(p.password);
}

void to_json(json & j, const SignupRequest & p)
{
	j = json{ { "username", p.username } , { "password", p.password } , { "email", p.email } };
}

void from_json(const json & j, SignupRequest & p)
{
	j.at("username").get_to(p.username);
	j.at("password").get_to(p.password);
	j.at("email").get_to(p.email);
}

void to_json(json & j, const GetPlayersInRoomRequest & p)
{
	j = json{ {"id", p.roomId} };
}

void from_json(const json & j, GetPlayersInRoomRequest & p)
{
	j.at("id").get_to(p.roomId);
}

void to_json(json & j, const JoinRoomRequest & p)
{
	j = json{ { "id", p.roomId } };
}

void from_json(const json & j, JoinRoomRequest & p)
{
	j.at("id").get_to(p.roomId);
}

void to_json(json & j, const CreateRoomRequest & p)
{
	j = json{ { "roomname", p.roomName }, {"maxusers", p.maxUsers }, {"questioncount", p.questionCount}, {"answertimeout", p.answerTimeout} };
}

void from_json(const json & j, CreateRoomRequest & p)
{
	j.at("roomname").get_to(p.roomName);
	j.at("maxusers").get_to(p.maxUsers);
	j.at("questioncount").get_to(p.questionCount);
	j.at("answertimeout").get_to(p.answerTimeout);
}

void to_json(json & j, const SubmitAnswerRequest & p)
{
	j = json{ { "answer", p.answer }, {"elapsed", p.timeUntilResponse} };
}

void from_json(const json & j, SubmitAnswerRequest & p)
{
	j.at("answer").get_to(p.answer);
	j.at("elapsed").get_to(p.timeUntilResponse);
}

void to_json(json & j, const LoggedUser & p)
{
	j = p.getUsername();
}

void from_json(const json& j, LoggedUser& p)
{
	p.setUsername(j);
}

void to_json(json & j, const Room & p)
{
	j = json{ {"players", p.getAllUsers()}, {"metadata", p.getMetadata()} };
}

void to_json(json & j, const RoomData & p)
{
	j = json{ {"roomid", p.id}, {"isactive", p.isActive}, {"maxplayers", p.maxPlayers}, {"roomname", p.name}, {"questioncount", p.numOfQuestions}, {"answertimeout", p.timePerQuestion} };
}

void to_json(json & j, const std::map<unsigned int, std::shared_ptr<Room>>& p)
{
	std::vector<Room> roomVec;
	for (auto i = p.begin(); i != p.end(); i++)
	{
		roomVec.push_back(*(i->second));
	}
	j = roomVec;
}

void to_json(json & j, const Question & p)
{
	j = json{ {"question", p.getQuestion()}, {"answers", p.getPossibleAnswers()} };
}

void to_json(json & j, const PlayerResults & p)
{
	j = json{ { "username", p.username }, {"correctanswers", p.correctAnswerCount}, {"wronganswers", p.wrongAnswerCount}, {"avgtime", p.averageAnswerTime} };
}

#pragma endregion JSON library Arbitrary types conversions