using PathfindingDemo.Gameplay.Enviroment;
using PathfindingDemo.Gameplay.Util;

namespace PathfindingDemo.Gameplay.Entities;
internal class Player : Entity
{
    public Player(World _world) : base(_world, new Position(0, 0))
    { }

    protected override void Update()
    {
        if (Input.KeyPressed(ConsoleKey.W))
            Move(Position.Up);

        if (Input.KeyPressed(ConsoleKey.A))
            Move(Position.Left);

        if (Input.KeyPressed(ConsoleKey.S))
            Move(Position.Right);

        if (Input.KeyPressed(ConsoleKey.D))
            Move(Position.Down);
    }
}
