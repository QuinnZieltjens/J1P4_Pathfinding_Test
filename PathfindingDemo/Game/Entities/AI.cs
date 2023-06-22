using PathfindingDemo.Game.Enviroment;
using PathfindingDemo.Game.Pathfinding;
using PathfindingDemo.Util.Physics;

namespace PathfindingDemo.Game.Entities;

internal class AI : Entity
{
    private IPathfinding pathfinding;   //the pathfinding algorithm used by the AI
    private List<Position> walkPath;

    public AI(World _world, IPathfinding _pathfinding) : base(_world, _pathfinding.Start)
    {
        pathfinding = _pathfinding;
        walkPath = new List<Position>();

        //set the colour
        Color = ConsoleColor.Magenta;

        CalculateRoute();
    }

    /// <summary>
    /// calculates the shortest path to <paramref name="_target"/> and goes there
    /// </summary>
    public void CalculateRoute()
    {
        Thread pathfinderThread = new(() =>
        {
            //get the shortest path via the pathfinding algorithm
            pathfinding.Run().Wait(); //run the algorithm

            walkPath = pathfinding.GetPathPositions().ToList();
        });

        pathfinderThread.Start();
    }

    protected override void Update()
    {
        if (walkPath.Count == 0) //if there are no positions to move
        {
            NewRoute(); //get a new route to walk
            return; //exit method
        }

        Position movePos = walkPath[0]; //get the next relative position to move to
        walkPath.RemoveAt(0); //remove the index 0

        //move to the position
        Move((Position - movePos) * -1);
    }

    private void NewRoute()
    {
        Random random = new();
        int x;
        int y;

        do
        {
            x = random.Next(0, World.SizeX - 1);
            y = random.Next(0, World.SizeY - 1);
        }
        while (World.IsWall(new Position(x, y)));

        pathfinding.Target = new Position(x, y);
        pathfinding.Start = Position;
        CalculateRoute();
    }
}
