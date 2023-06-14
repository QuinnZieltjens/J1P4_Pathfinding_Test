using Newtonsoft.Json;
using PathfindingDemo.Gameplay.Entities;
using PathfindingDemo.Gameplay.Enviroment;

namespace PathfindingDemo;

internal class Game : GameBehaviour
{
    private const string WorldBuilderPath = "./Assets/Settings/WorldBuilder.json";

    private readonly World world;
    private readonly List<Entity> entities;
    private readonly Display display;

    public Game()
    {
        string jsonData = File.ReadAllText(WorldBuilderPath);
        WorldBuilder worldBuilder = JsonConvert.DeserializeObject<WorldBuilder>(jsonData) ?? throw new Exception("incorrect json format!");

        world = worldBuilder.Build();
        entities = new List<Entity>() { };
        display = new Display(world, entities);
    }
}
