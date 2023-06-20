using PathfindingDemo.Gameplay.Enviroment;
using PathfindingDemo.Util.Physics;
using System.Diagnostics;

namespace PathfindingDemo.Gameplay.Entities;

internal class AStar : Entity
{
    private int cost;
    private Position targetPos;

    public AStar(World _world, Position _startPos, Position _targetPos) : base(_world, _startPos)
    {
        targetPos = _targetPos;
        Color = ConsoleColor.Magenta;
    }

    protected override void Start()
    {
    }

    protected override void Update()
    {
        Dictionary<double, List<Position>> locations = new();

        //local function
        void TryAddPos(Position _pos)
        {
            //if the position isn't a wall
            if (World.IsWall(_pos) == false)
            {
                double h = CalculateCost(_pos); //calculate the heuristic

                Display.DebugMark(_pos.X, _pos.Y);

                if (!locations.ContainsKey(h))
                    locations.Add(h, new List<Position>());

                locations[h].Add(_pos); // add the position to the list for the corresponding heuristic
            }
        }

        TryAddPos(Position.Up + Position);
        TryAddPos(Position.Down + Position);
        TryAddPos(Position.Left + Position);
        TryAddPos(Position.Right + Position);

        if (locations.Count == 0)
            return;

        List<double> locationKeys = locations.Keys.ToList();
        locationKeys.Sort();
        List<Position> positions = locations[locationKeys[0]];
        Position movePos = positions[new Random().Next(positions.Count)];

        Move(movePos - Position);
        cost++;
    }

    private double CalculateCost(Position _target)
    {
        //local function to raise _x to the power of two
        double Square(double _x) => Math.Pow(_x, 2);

        //break vectors
        int x1 = _target.X;
        int y1 = _target.Y;
        int x2 = targetPos.X;
        int y2 = targetPos.Y;

        //get the absolute values of X and Y squared
        double x = Math.Abs(Square(x1 - x2));
        double y = Math.Abs(Square(y1 - y2));

        //get the square root of x + y to get the heuristic (optimistic value for the pathfinding algorithm)
        return Math.Sqrt(x + y) + cost;
    }
}
