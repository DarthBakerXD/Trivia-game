#pragma once
#include <iostream>
#include <vector>


class Question
{
public:

	Question();
	Question(std::string question, std::vector<std::string> answers);
	std::string getQuestion() const;
	std::vector<std::string> getPossibleAnswers() const;
	std::string getCorrectAnswer();
	bool operator==(const Question& right);

private:

	std::string m_question;
	std::vector<std::string> m_possibleAnswers;

};