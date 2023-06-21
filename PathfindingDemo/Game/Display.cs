using PathfindingDemo.Game.Entities;
using PathfindingDemo.Game.Enviroment;
using PathfindingDemo.Util;
using PathfindingDemo.Util.Physics;
using System.Diagnostics;

namespace PathfindingDemo.Game;

internal class Display : GameBehaviour
{
    private const int OffsetX = 5; //set's the offset in the X axis that the world is drawn
    private const int OffsetY = 3; //set's the offset in the Y axis that the world is drawn

    private readonly World world;                               //contains the world that is drawn
    private readonly IReadOnlyCollection<Entity> entities;      //contains the entities that are contained in the world
    private readonly List<Position> drawnEntityPositionCache;   //cache for all the positions that an entity has been drawn

    /// <summary>
    /// displays <paramref name="_world"/> and <paramref name="_entities"/> to the console output
    /// </summary>
    public Display(World _world)
    {
        world = _world;
        entities = world.Entities;
        drawnEntityPositionCache = new List<Position>();
    }

    /// <summary>
    /// marks the tile at position <paramref name="_x"/> <paramref name="_y"/> off with "<c>.</c>"<br/>
    /// with the colour <paramref name="_color"/> and the background colour <see cref="ConsoleColor.Black"/>
    /// </summary>
    public static void DebugMark(int _x, int _y, ConsoleColor _color = ConsoleColor.DarkGray)
    {
        //if the debugger isn't attached, exit method
        if (Debugger.IsAttached == false)
            return;

        Console.SetCursorPosition(_x + OffsetX, _y + OffsetY);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = _color;
        Console.Write('.');
    }

    //is called before the first frame
    protected override void Start()
    {
        //hide the cursor
        Console.CursorVisible = false;

        //draw the world
        DrawWorld();
    }

    //is called every frame
    protected override void Update()
    {
        //clear the drawn entities
        ClearDrawnEntities();

        //draw the entities again
        DrawEntities();
    }

    /// <summary>
    /// goes through <see cref="drawnEntityPositionCache"/> and clears the tile, then clears the cache
    /// </summary>
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

    /// <summary>
    /// draws all the entities in <see cref="entities"/> at their positions and saves them in <see cref="drawnEntityPositionCache"/>
    /// </summary>
    private void DrawEntities()
    {
        //loop through the entities
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

    /// <summary>
    /// loops through the world and draws a <see cref="ConsoleColor.White"/> square<br/>
    /// if <see cref="World.IsWall(Position)"/> returns <see langword="true"/>
    /// </summary>
    private void DrawWorld()
    {
        //loop through the Y axis of the world
        for (int x = -1; x <= world.SizeX; x++)
        {
            //loop through the Y axis of the world
            for (int y = -1; y <= world.SizeY; y++)
            {
                //get the whether the position is a wall and save the correct colour
                ConsoleColor color = world.IsWall(new Position(x, y)) ? ConsoleColor.White : ConsoleColor.Black;

                //set the tile at X & Y to that colour
                DrawAt(x, y, color);
            }
        }
    }


    /// <summary>
    /// sets <see cref="Console.BackgroundColor"/> to <paramref name="_color"/> at (<paramref name="_x"/>, <paramref name="_y"/>)
    /// </summary>
    private static void DrawAt(int _x, int _y, ConsoleColor _color)
    {
        //set the cursor position to the correct tile
        Console.SetCursorPosition(_x + OffsetX, _y + OffsetY);

        //draw the colour
        Draw(_color);
    }

    /// <summary>
    /// sets <see cref="Console.BackgroundColor"/> to <paramref name="_color"/> at the current console's position
    /// </summary>
    private static void Draw(ConsoleColor _color)
    {
        //set the background colour to the value
        Console.BackgroundColor = _color;

        //draw a space
        Console.Write(' ');
    }
}
