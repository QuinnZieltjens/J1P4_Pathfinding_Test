using PathfindingDemo.Gameplay.Enviroment;
using PathfindingDemo.Util.Physics;

namespace PathfindingDemo.Gameplay.Entities;

internal class AStar : Entity
{
    private Position targetPos;

    public AStar(World _world, Position _startPos, Position _targetPos) : base(_world, _startPos)
    {
        targetPos = _targetPos;
        Color = ConsoleColor.Magenta;
    }

    protected override void Start()
    {
        
    }
}
