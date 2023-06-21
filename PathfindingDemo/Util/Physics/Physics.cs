using PathfindingDemo.Game.Enviroment;

namespace PathfindingDemo.Util.Physics;

internal static partial class Physics
{
    /// <param name="_world">the world in which the raycast is ran</param>
    /// <param name="_startPos">the starting position of the raycast</param>
    /// <param name="_endPos">the position that the raycast will travel to</param>
    /// <returns>an instance of <see cref="RaycastHit"/></returns>
    public static RaycastHit DrawRay(World _world, Position _startPos, Position _endPos)
    {
        //create a raycast object
        Raycast raycast = new(_world, _startPos, _endPos);

        //draw the ray and return the results
        return raycast.DrawRay();
    }
}
