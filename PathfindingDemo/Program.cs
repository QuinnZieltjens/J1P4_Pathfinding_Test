using Newtonsoft.Json;

namespace PathfindingDemo;

internal class Program
{
    private static void Main()
    {
        TaskScheduler taskScheduler = new();
        Game game = new();
        taskScheduler.Start();

        //if the game didn't start
        if (game.GameStarted == false)
            throw new Exception("something went wrong whilst attempting to start the game");
    }
}
