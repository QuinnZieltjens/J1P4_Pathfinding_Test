using PathfindingDemo.Game;
using PathfindingDemo.Util;

namespace PathfindingDemo;

internal class Program
{
    private static void Main()
    {
        GameTasks gameTasks = new();
        Game.Game game = new();
        gameTasks.Start();

        //if the game didn't start
        if (game.GameStarted == false)
            throw new Exception("something went wrong whilst attempting to start the game");
    }
}
