using PathfindingDemo.Game.Enviroment;
using PathfindingDemo.Util.Physics;
using System.ComponentModel.DataAnnotations;

namespace PathfindingDemo.Game.Pathfinding;

internal interface IPathfinding
{
    [Required()] public Position Start { get; set; }
    [Required()] public Position Target { get; set; }
    [Required()] public World World { get; init; }

    public IReadOnlyCollection<Position> GetPathPositions();
    public Task Run();
}
