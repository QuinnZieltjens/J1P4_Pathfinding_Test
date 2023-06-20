using Newtonsoft.Json;
using PathfindingDemo.Gameplay.Entities;
using PathfindingDemo.Gameplay.Enviroment;
using PathfindingDemo.Util;

namespace PathfindingDemo.Gameplay;

internal class Game : GameBehaviour
{
    private const string WorldBuilderPath = "./Assets/Settings/WorldBuilder.json";

    public bool GameStarted { get; private set; }

    private readonly World world;
    private readonly List<Entity> entities;
    private readonly Display display;

    public Game()
    {
        string jsonData = File.ReadAllText(WorldBuilderPath);
        WorldBuilder worldBuilder = JsonConvert.DeserializeObject<WorldBuilder>(jsonData) ?? throw new Exception("incorrect json format!");

        world = worldBuilder.Build();
        entities = new List<Entity>();
        display = new Display(world, entities);
    }

    protected override void Start()
    {
        entities.Add(new Player(world, new(4, 3)));
        entities.Add(new AStar(world, new(0, 0), new(world.SizeX - 1, world.SizeY - 1)));

        GameStarted = true;
    }
}
