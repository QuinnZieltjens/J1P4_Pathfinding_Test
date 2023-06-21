using PathfindingDemo.Game.Enviroment;
using PathfindingDemo.Util;
using PathfindingDemo.Util.Physics;

namespace PathfindingDemo.Game.Entities;
internal class Player : Entity
{
    public Player(World _world, Position _pos) : base(_world, _pos)
    {
        Color = ConsoleColor.Green;
    }

    protected override void Update()
    {
        //ignore that W = Down and S = Up, the builder reads the Y-axis flipped
        if (Input.GetKeyDown(ConsoleKey.W))
            Move(Position.Down);

        if (Input.GetKeyDown(ConsoleKey.A))
            Move(Position.Left);

        if (Input.GetKeyDown(ConsoleKey.S))
            Move(Position.Up);

        if (Input.GetKeyDown(ConsoleKey.D))
            Move(Position.Right);
    }
}
