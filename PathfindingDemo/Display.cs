using PathfindingDemo.Gameplay.Entities;
using PathfindingDemo.Gameplay.Enviroment;

namespace PathfindingDemo;

internal class Display : GameBehaviour
{
    private readonly World world;
    private readonly List<Entity> entities;

    public Display(World _world, List<Entity> _entities)
    {
        world = _world;
        entities = _entities;
    }

    protected override void Start()
    {
        //hide the cursor
        Console.CursorVisible = false;

        //draw the world
        DrawWorld();
    }

    protected override void Update()
    {

    }

    private void DrawWorld()
    {
        for (int x = 0; x < world.SizeX; x++)
        {
            for (int y = 0; y < world.SizeY; y++)
            {
                ConsoleColor color = world.IsWall((x, y)) ? ConsoleColor.White : ConsoleColor.Black;
                DrawAt(x, y, color);
            }
        }
    }

    private static void DrawAt(int _x, int _y, ConsoleColor _color)
    {
        Console.SetCursorPosition(_x, _y);
        Draw(_color);
    }

    private static void Draw(ConsoleColor _color)
    {
        Console.BackgroundColor = _color;
        Console.Write(' ');
    }
}
