#define DOCTEST_CONFIG_IMPLEMENT_WITH_MAIN
#include "doctest.h"
#include "ConsoleTwitter.h"

TEST_CASE("Empty timeline for Alice before post"){
	std::string output = sendInput("Alice");

	CHECK_EQ("Alice Timeline\nNo posts found\n", output);
}

TEST_CASE("Empty wall for Alice before post"){
	std::string output = sendInput("Alice wall");

	CHECK_EQ("Alice wall\nNo posts found\n", output);
}

TEST_CASE("One post on Alice's timeline after posting"){
	std::string output = sendInput("Alice -> A message");

	CHECK_EQ("Alice posted message 'A message'\n", output);

	output = sendInput("Alice");

	CHECK_EQ("Alice Timeline\nA message\n", output);
}
