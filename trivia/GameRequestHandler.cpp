#include "GameRequestHandler.h"
#include "LoginRequestHandler.h"
#include "DatabaseException.h"
#include "GameManagerException.h"
#include "JSONHandlers.h"
#include "MenuRequestHandler.h"

#define GETQUESTION_CODE "131"
#define SUBMITANSWER_CODE "132"
#define GETGAMERESULTS_CODE "133"
#define LEAVEGAME_CODE "134"
#define GETQUESTION_RESPONSE "231"
#define SUBMITANSWER_RESPONSE "232"
#define GETGAMERESULTS_RESPONSE "233"
#define LEAVEGAME_RESPONSE "234"
#define NON_CODE_CHAR 3
#define STATUS_SUCCESS 0
#define STATUS_ROOM_ISSUE 1

GameRequestHandler::GameRequestHandler(LoggedUser user, GameManager& manager, std::shared_ptr<Game> game, IDatabase& db, RequestHandlerFactory* handlerFactory) : m_user(user), m_gameManager(manager), m_game(game), m_database(db), m_handlerFactory(handlerFactory)
{}



bool GameRequestHandler::isRequestRelevant(const Request& request)
{
	if (!request.buffer.rfind(GETQUESTION_CODE, 0) || !request.buffer.rfind(SUBMITANSWER_CODE, 0) || !request.buffer.rfind(GETGAMERESULTS_CODE, 0) || !request.buffer.rfind(LEAVEGAME_CODE, 0))
	{
		return true;
	}
	return false;
}



RequestResult GameRequestHandler::handleRequest(const Request& request)
{
	if (!request.buffer.rfind(GETQUESTION_CODE, 0))
	{
		return getQuestion(request);
	}
	if (!request.buffer.rfind(SUBMITANSWER_CODE, 0))
	{
		return submitAnswer(request);
	}
	if (!request.buffer.rfind(GETGAMERESULTS_CODE, 0))
	{
		return getGameResults(request);
	}

	return leaveGame(request);
}


RequestResult GameRequestHandler::getQuestion(const Request& request)
{
	RequestResult resp;
	GetQuestionResponse success;
	success.status = STATUS_SUCCESS;
	success.question = m_game->getQuestionForUser(m_user);
	std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
	msg = GETQUESTION_RESPONSE + msg;
	resp.newHandler = nullptr;
	resp.response = msg;
	return resp;
}


RequestResult GameRequestHandler::submitAnswer(const Request& request)
{
	RequestResult resp;
	SubmitAnswerResponse success;
	std::string serializedRequest = request.buffer.substr(NON_CODE_CHAR);
	SubmitAnswerRequest req = JsonRequestPacketDeserializer::deserializeSubmitAnswerRequest(serializedRequest);
	success.status = STATUS_SUCCESS;
	success.correctAnswer = m_game->submitAnswer(m_user, req.answer, req.timeUntilResponse);
	std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
	msg = SUBMITANSWER_RESPONSE + msg;
	resp.newHandler = nullptr;
	resp.response = msg;
	return resp;
}


RequestResult GameRequestHandler::getGameResults(const Request& request)
{
	RequestResult resp;
	GetGameResultsResponse success;
	success.status = STATUS_SUCCESS;
	success.results.clear();
	std::map<LoggedUser, GameData> players = m_game->getPlayers();
	PlayerResults results;
	for (auto i = players.begin(); i != players.end(); i++)
	{
		results.username = i->first.getUsername();
		results.correctAnswerCount = i->second.correctAnswerCount;
		results.wrongAnswerCount = i->second.wrongAnswerCount;
		results.averageAnswerTime = i->second.averageAnswerTime;
		success.results.push_back(results);
	}
	std::string msg = JsonResponsePacketSerializer::serializeResponse(success);
	msg = GETGAMERESULTS_RESPONSE + msg;
	resp.newHandler = nullptr;
	resp.response = msg;
	return resp;
}


RequestResult GameRequestHandler::leaveGame(const Request& request)
{
	RequestResult resp;
	auto players = m_game->getPlayers();
	auto stats = players.find(LoggedUser(m_user))->second;
	m_game->removePlayer(m_user);
	if (m_game->getPlayers().size() == 0) // If game is empty, delete it.
	{
		m_gameManager.deleteGame(m_game);
	}
	PlayerResults endResults;
	endResults.username = m_user.getUsername();
	endResults.correctAnswerCount = stats.correctAnswerCount;
	endResults.wrongAnswerCount = stats.wrongAnswerCount;
	endResults.averageAnswerTime = stats.averageAnswerTime;
	m_database.updateUserStats(endResults);
	resp.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	resp.response = LEAVEGAME_RESPONSE;
	return resp;
}