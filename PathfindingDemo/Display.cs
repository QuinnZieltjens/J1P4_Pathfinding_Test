using PathfindingDemo.Gameplay.Entities;
using PathfindingDemo.Gameplay.Enviroment;
using PathfindingDemo.Gameplay.Util;

namespace PathfindingDemo;

internal class Display : GameBehaviour
{
    private readonly World world;
    private readonly List<Entity> entities;
    private readonly List<Position> drawnEntityPositionCache;

    public Display(World _world, List<Entity> _entities)
    {
        world = _world;
        entities = _entities;
        drawnEntityPositionCache = new List<Position>();
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
        ClearDrawnEntities();
        DrawEntities();
    }

    private void ClearDrawnEntities()
    {
        //loop through the cached positions
        foreach (Position drawnPosition in drawnEntityPositionCache)
        {
            //set the drawn position to black
            DrawAt(drawnPosition.X, drawnPosition.Y, ConsoleColor.Black);
        }

        //clear the entity cache
        drawnEntityPositionCache.Clear();
    }

    private void DrawEntities()
    {
        foreach (Entity entity in entities)
        {
            //break the entity vector position
            int posX = entity.Position.X;
            int posY = entity.Position.Y;

            //draw the entities colour at the position
            DrawAt(posX, posY, entity.Color);

            //cache the position of the drawn entity
            drawnEntityPositionCache.Add(new Position(posX, posY));
        }
    }

    private void DrawWorld()
    {
        for (int x = 0; x < world.SizeX; x++)
        {
            for (int y = 0; y < world.SizeY; y++)
            {
                ConsoleColor color = world.IsWall(new Position(x, y)) ? ConsoleColor.White : ConsoleColor.Black;
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
