using PathfindingDemo.Gameplay;
using PathfindingDemo.Gameplay.Enviroment;
using System.Diagnostics;

namespace PathfindingDemo.Util.Physics;


internal class Raycast
{
    private readonly World world;

    private readonly int x1;     //x for point 1
    private readonly int y1;     //y for point 1
    private readonly int x2;     //x for point 2
    private readonly int y2;     //y for point 2
    private readonly float m;    //the slope of the line


    public Raycast(World _world, Position _startPos, Position _endPos)
    {
        //save the world
        world = _world;

        //break vectors
        x1 = _startPos.X;
        y1 = _startPos.Y;
        x2 = _endPos.X;
        y2 = _endPos.Y;

        //get slope
        if (x1 == x2 || y1 == y2) //if the x or y axis is equal
            m = 0f; //a slope of 0
        else
            m = (y2 - y1) / (x2 - x1); //calculate the slope
    }

    public RaycastHit DrawRay()
    {
        //if the end and start positions are equal
        if (x1 == x2 && y1 == y2)
            return new RaycastHit(); //the raycast didn't hit anything

        //return a raycastHit
        return RunRaycast();
    }

    private RaycastHit RunRaycast()
    {
        Position endPos = Position.Zero;
        bool usingAxisY = x1 == x2;
        bool Condition(int _n) => usingAxisY ? ConditionY(_n) : ConditionX(_n);
        bool ConditionX(int _x) => GetAddX() == 1 ? _x <= x2 : _x >= x2;
        bool ConditionY(int _y) => GetAddY() == 1 ? _y <= y2 : _y >= y2;

        int GetAdd() => usingAxisY ? GetAddY() : GetAddX();
        int GetAddX() => x1 > x2 ? -1 : 1;
        int GetAddY() => y1 > y2 ? -1 : 1;

        float Calculate(int _n) => usingAxisY ? CalculateX(_n) : CalculateY(_n);
        float CalculateX(int _y) => m * (_y - y1) + x1;
        float CalculateY(int _x) => m * (_x - x1) + y1;

        //TODO: repetition! - please fix

        if (usingAxisY)
        {
            for (int y = y1; Condition(y); y += GetAdd())
            {
                int x = (int)Math.Round(Calculate(y));
                Position currentPos = new(x, y);

                Display.DebugMark(x, y, ConsoleColor.Red);

                if (world.IsWall(currentPos))
                    return new RaycastHit(true, endPos);

                endPos = currentPos;
            }
        }
        else
        {
            for (int x = x1; Condition(x); x += GetAdd())
            {
                int y = (int)Math.Round(Calculate(x));
                Position currentPos = new(x, y);

                Display.DebugMark(x, y, ConsoleColor.Red);

                if (world.IsWall(currentPos))
                    return new RaycastHit(true, endPos);

                endPos = currentPos;
            }
        }

        //return the last ray position with a raycastHit that didn't hit anything
        return new RaycastHit(false, endPos);
    }
}

