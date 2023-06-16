namespace PathfindingDemo.Gameplay.Util;

/// <summary>
/// holds whether a raycast hit a wall and the position it got to (before hitting a wall if it did)
/// </summary>
internal struct RaycastHit
{
    private Position? hitPosition;

    public Position HitPosition { get => hitPosition ?? throw new NullReferenceException("no position was set"); }
    public bool Hit { get; }

    public RaycastHit(bool _hit, Position _lastPos)
    {
        hitPosition = _lastPos;
        Hit = _hit;
    }

    public RaycastHit(bool _hit)
    {
        Hit = _hit;
        hitPosition = null;
    }
}
