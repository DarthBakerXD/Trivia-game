#include "Question.h"



Question::Question()
{}

Question::Question(std::string question, std::vector<std::string> answers) : m_question(question), m_possibleAnswers(answers)
{}

std::string Question::getQuestion() const
{
	return m_question;
}


std::vector<std::string> Question::getPossibleAnswers() const
{
	return m_possibleAnswers;
}


std::string Question::getCorrectAnswer()
{
	return m_possibleAnswers[0];
}

bool Question::operator==(const Question& right)
{
	return m_question == right.m_question && m_possibleAnswers == right.m_possibleAnswers;
}