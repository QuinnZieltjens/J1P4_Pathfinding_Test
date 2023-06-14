using PathfindingDemo.Gameplay.Util;

namespace PathfindingDemo.Gameplay.Entities;
internal class PlayerEntity : Entity
{
    public PlayerEntity() : base(new Position(0, 0))
    {
        Color = ConsoleColor.Red;
    }
}
