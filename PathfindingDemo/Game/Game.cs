using Newtonsoft.Json;
using PathfindingDemo.Game.Entities;
using PathfindingDemo.Game.Enviroment;
using PathfindingDemo.Util;

namespace PathfindingDemo.Game;

internal class Game : GameBehaviour
{
    private const string WorldBuilderPath = "./Assets/Settings/WorldBuilder.json";

    public bool GameStarted { get; private set; }

    private readonly World world;
    private readonly Display display;

    public Game()
    {
        string jsonData = File.ReadAllText(WorldBuilderPath);
        WorldBuilder worldBuilder = JsonConvert.DeserializeObject<WorldBuilder>(jsonData) ?? throw new Exception("incorrect json format!");

        world = worldBuilder.Build();
        display = new Display(world);
    }

    protected override void Start()
    {
        //add the entities to the world
        world.AddEntity(new Player(world, new(4, 3)));
        world.AddEntity(new AI(world, new(0, 0), new(world.SizeX - 1, world.SizeY - 1)));

        GameStarted = true;
    }
}
