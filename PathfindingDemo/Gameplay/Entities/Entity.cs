using PathfindingDemo.Gameplay.Enviroment;
using PathfindingDemo.Gameplay.Util;

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
    protected void Move(Position _direction)
    {
        //calculate the new position
        Position newPos = Position + _direction;

        //set the position to the result of the raycast
        Position = DrawRay(Position, newPos);
    }

#warning should be moved in a separate class but I can't be bothered rn
    /// <summary>
    /// draws a ray from <paramref name="_pos1"/> to <paramref name="_pos2"/> and stops if it<br/>
    /// encounters a wall in <see cref="World"/>. Returns the final position of the ray.
    /// </summary>
    private Position DrawRay(Position _pos1, Position _pos2)
    {
        //algebra variables
        int x1, x2, y1, y2; //positions of the broken vectors
        float m; //slope op the line between pos1 and pos2

        //method variables
        int start, end; //to represent the right values 
        bool xEqual, yEqual; //whether the axis is equal
        bool mNegative; //whether the slope is negative
        Position? rayEnd; //set to the position of the ray after firing

        //set the end of the ray to null
        rayEnd = null;

        //set variables
        x1 = _pos1.X;
        y1 = _pos1.Y;
        x2 = _pos2.X;
        y2 = _pos2.Y;

        //check whether x or y is equal to prevent dividing by 0
        xEqual = x1 == x2;
        yEqual = y1 == y2;

        //the start and end to use the x axis
        start = x1;
        end = x2;


        if (xEqual && yEqual) //y & x are both equal
        {
            //return the current position
            return new Position(x1, y1);
        }
        else if (xEqual || yEqual) //either are equal
        {
            //set the slope to zero
            m = 0;
        }
        else //neither are equal
        {
            //calculate the slope
            m = (y2 - y1) / (x2 - x1);
        }

        //if the x axis is equal
        if (xEqual)
        {
            //use the y axis for start and end
            start = y1;
            end = y2;
        }

        //safe whether the slope is negative
        mNegative = m < 0;

        //loops through an axis we'll call 'x'
        for (int x = start; mNegative ? (x < end) : (x > end); x += mNegative ? 1 : -1)
        {
            //calculate the 'y' of said axis
            int y = (int)Math.Floor(m * (x - start));
            Position checkPos;

            //correctly set the check position (if x is equal we loop over the y axis)
            if (xEqual)
                checkPos = new Position(y, x);
            else
                checkPos = new Position(x, y);

            //if (x, y) is a wall
            if (World.IsWall(checkPos))
                break; //break the loop as we have our answer

            //store the raycast 
            rayEnd = new Position(x, y);
        }

        //set rayEnd to the current position if rayEnd is null (this means we are standing in a wall)
        rayEnd ??= new Position(x1, y1);

        //return rayEnd
        return (Position)rayEnd;
    }
}
