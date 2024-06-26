namespace ConsoleTwitter;

using System.Linq;

public class ConsoleTwitter
{
    Posts posts = new Posts();
    Dictionary<string, Users> followed = new Dictionary<string, Users>();

    public string sendInput(string command)
    {
        var commandWords = parseCommand(command);

        if (commandWords.Count == 1)
        {
            var userName = commandWords.First();
            return formatOutput(userName, "Timeline", userPosts(userName), false);
        }

        if (commandWords.Count == 2)
        {
            var userName = commandWords.First();
            var userCommand = commandWords.Last();
            if (userCommand != "wall")
                return "Bad command '" + command + "'";
            return formatOutput(userName, "Wall", userAndFollowedPosts(userName), true);
        }

        if (commandWords.Count >= 3)
        {
            var userName = commandWords.First();
            commandWords.RemoveAt(0);

            var theCommand = commandWords.First();
            if (theCommand != "->" && theCommand != "follows")
                return "Bad command '" + command + "'";

            if (theCommand == "->")
            {
                commandWords.RemoveAt(0);
                string message = String.Join(" ", commandWords);
                Post post = new Post(userName, message);
                posts.Add(post);
                return $"{userName} posted message '{message}'\n";
            }

            if (theCommand == "follows")
            {
                commandWords.RemoveAt(0);
                string whoToFollow = commandWords.First();
                if (!followed.ContainsKey(userName))
                {
                    followed.Add(userName, new Users());
                }
                followed[userName].Add(whoToFollow);
                return $"{userName} is now following {whoToFollow}\n";
            }
        }
        return $"Bad command '{command}'";
    }

    private CommandParts parseCommand(string command)
    {
        return new CommandParts(command.Split(' '));
    }

    private string formatOutput(string userName, string header)
    {
        return formatOutput(userName, header, this.posts, false);
    }

    private string formatOutput(string userName, string header, Posts posts, bool withUser)
    {
        if (posts.Count == 0)
        {
            return $"{userName} {header}\nNo posts found\n";
        }
        else
        {
            if (withUser)
            {
                var formattedPosts = posts.Select(post => $"{post.UserName} - {post.Message}");
                string allPosts = String.Join("\n", formattedPosts);
                return $"{userName} {header}\n{allPosts}\n";
            }
            else
            {
                var formattedPosts = posts.Select(post => $"{post.Message}");
                string allPosts = String.Join("\n", formattedPosts);
                return $"{userName} {header}\n{allPosts}\n";
            }
        }
    }

    Posts userPosts(string userName)
    {
        return new Posts(posts.Where(it => it.UserName == userName));
    }

    Posts userAndFollowedPosts(string userName)
    {
        return new Posts(
            posts.Where(it => it.UserName == userName || followed[userName].Contains(it.UserName))
        );
    }
}
