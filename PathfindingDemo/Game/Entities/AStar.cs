using PathfindingDemo.Game.Enviroment;
using PathfindingDemo.Util.Physics;

namespace PathfindingDemo.Game.Entities;

internal class AStar : Entity
{
    private readonly Position targetPos;        //the target position the algorithm will move to
    private readonly List<Position> walkPath;   //the path that the algorithm will walk

    public AStar(World _world, Position _startPos, Position _targetPos) : base(_world, _startPos)
    {
        targetPos = _targetPos;
        walkPath = new List<Position>();

        //set the colour
        Color = ConsoleColor.Magenta;
    }

    /// <summary>
    /// calculates the shortest path to <paramref name="_position"/> and goes there
    /// </summary>
    public void MoveTo(Position _position)
    {
        int g; //cost from the start node to the current node
        int h; //heuristic of the estimated distance from the current node to target

        //clear the path that is being walked
        walkPath.Clear();


        // f = g + h
        // h = (x1) - (x2) + (y1) - (y2) cost from n to target
        // g = cost from start to current

        // find a way to somehow store the relative positions to move to
    }

    protected override void Start()
    {
        // move A* to the target position
        MoveTo(targetPos);
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
