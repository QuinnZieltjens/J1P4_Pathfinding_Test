using PathfindingDemo.Gameplay.Enviroment;
using PathfindingDemo.Gameplay.Util;
using PathfindingDemo.Gameplay.Util.Physics;

namespace PathfindingDemo.Gameplay.Entities;

internal abstract class Entity : GameBehaviour
{
    public Position Position { get; set; }
    public ConsoleColor Color { get; protected init; }
    protected World World { get; }

    /// <summary>
    /// create an entity object with the start position
    /// </summary>
    public Entity(World _world, Position _position)
    {
        Color = ConsoleColor.Gray; //set the default entity colour to gray

        //set the starting variables
        World = _world;
        Position = _position;
    }

    /// <summary>
    /// sets <see cref="Position"/> to that plus <paramref name="_direction"/>,<br/>
    /// if this path encounters a wall the position is set to the space before
    /// </summary>
    /// <returns><see langword="true"/> if the entity hit a wall, otherwise <see langword="false"/></returns>
    protected bool Move(Position _direction)
    {
        //calculate the new position
        Position newPos = Position + _direction;

        //draw a raycast in world from the current position to the new position
        RaycastHit hit = Physics.DrawRay(World, Position, newPos);

        //set the entity's position to the raycast's position
        Position = hit.HitPosition;

        return hit.Hit;
    }
}
