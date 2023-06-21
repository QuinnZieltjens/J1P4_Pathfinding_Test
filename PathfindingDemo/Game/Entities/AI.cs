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
    }

    /// <summary>
    /// calculates the shortest path to <paramref name="_target"/> and goes there
    /// </summary>
    public async void CalculateRoute(Position _target)
    {
        //get the shortest path via the pathfinding algorithm
        pathfinding.Start = Position; //set the start node
        pathfinding.Target = _target; //set the target node
        await pathfinding.Run(); //run the algorithm
    }

    protected override void Start()
    {
        CalculateRoute(pathfinding.Target);
    }

    protected override void Update()
    {
        if (walkPath.Count == 0) //if there are no positions to move
            return; //exit method

        Position moveDirection = walkPath[0]; //get the next relative position to move to
        walkPath.RemoveAt(0); //remove the index 0

        //move to the position
        Move(moveDirection);
    }
}
