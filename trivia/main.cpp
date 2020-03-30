#include <exception>
#include "Server.h"

int main(void)
{
	try
	{
		Server server;
		server.run();
	}
	catch (const std::exception& e)
	{
		std::cout << e.what() << std::endl;
		return -1;
	}
	return 0;
}