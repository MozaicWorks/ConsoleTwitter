# Console Twitter

This codebase implements a simplified version of Twitter using commands passed from console. The implementation is naive, allowing for various refactoring exercises and design conversations.

## Practice Exercises

Here are a few possible exercises that you can run on this codebase:

* Introduce a new command "history" that shows the list of all commands ran on the system
* Introduce a new command "undo" that undoes the last command ran on the system, except the "history" command. The history will contain the "undo" command as well
* Introduce a new command "<username> draft" that allows a user to save a single draft post
* Introduce a new command "<username> clear-draft" that deletes the draft if it exists, and outputs "nothing to delete" if no draft exists
* Introduce a new command "<username> post-draft" that posts the draft if it exists, and outputs "no draft to post" if no draft exists

## Hints:

* take a look at the Command, State, Memento, and Decorator design patterns. You might want to try a few of them while solving the problem
* you can also take a functional programming approach. Eg. make every command a lambda and use immutable data structures


## Inspiration

The codebase was inspired by the [Twitter Kata by Sandro Mancuso](https://github.com/sandromancuso/twitter-kata-java), but it is implemented with a different goal.
