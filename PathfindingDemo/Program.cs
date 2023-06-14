using Newtonsoft.Json;

namespace PathfindingDemo;

internal class Program
{
    private static void Main()
    {
        Game game = new();
        GameBehaviour.StartGame(game);
    }
}
