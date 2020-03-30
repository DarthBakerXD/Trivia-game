#pragma once

#include "IRequestHandler.h"
#include "Game.h"
#include "LoggedUser.h"
#include "GameManager.h"
#include "RequestHandlerFactory.h"


class GameRequestHandler : public IRequestHandler
{

public:

	GameRequestHandler(LoggedUser user, GameManager& manager, std::shared_ptr<Game> game, IDatabase& db, RequestHandlerFactory* handlerFactory);
	virtual bool isRequestRelevant(const Request& request);
	virtual RequestResult handleRequest(const Request& request);

private:

	std::shared_ptr<Game> m_game;
	LoggedUser m_user;
	GameManager& m_gameManager;
	IDatabase& m_database;
	RequestHandlerFactory* m_handlerFactory;
	RequestResult getQuestion(const Request& request);
	RequestResult submitAnswer(const Request& request);
	RequestResult getGameResults(const Request& request);
	RequestResult leaveGame(const Request& request);

};