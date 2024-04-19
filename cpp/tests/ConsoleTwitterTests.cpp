#define DOCTEST_CONFIG_IMPLEMENT_WITH_MAIN
#include "doctest.h"
#include "ConsoleTwitter.h"

TEST_CASE("Empty timeline for Alice before post"){
	ConsoleTwitter consoleTwitter;
	string output = consoleTwitter.sendInput("Alice");

	CHECK_EQ("Alice Timeline\nNo posts found\n", output);
}

TEST_CASE("Empty wall for Alice before post"){
	ConsoleTwitter consoleTwitter;
	string output = consoleTwitter.sendInput("Alice wall");

	CHECK_EQ("Alice Wall\nNo posts found\n", output);
}

TEST_CASE("One post on Alice's timeline after posting"){
	ConsoleTwitter consoleTwitter;
	string output = consoleTwitter.sendInput("Alice -> A message");

	CHECK_EQ("Alice posted message 'A message'\n", output);

	output = consoleTwitter.sendInput("Alice");

	CHECK_EQ("Alice Timeline\nA message\n", output);
}

TEST_CASE("Bob's timeline is empty after Alice posts") {
	ConsoleTwitter consoleTwitter;
	string output = consoleTwitter.sendInput("Alice -> A message");

	output = consoleTwitter.sendInput("Bob");

	CHECK_EQ("Bob Timeline\nNo posts found\n", output);
}

TEST_CASE("Bob's timeline shows only Bob's post after both Alice and Bob post") {
	ConsoleTwitter consoleTwitter;
	consoleTwitter.sendInput("Alice -> Alice's message");
	consoleTwitter.sendInput("Bob -> Bob's message");

	string output = consoleTwitter.sendInput("Bob");

	CHECK_EQ("Bob Timeline\nBob's message\n", output);
}
