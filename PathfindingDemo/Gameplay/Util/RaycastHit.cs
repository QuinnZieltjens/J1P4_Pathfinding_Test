namespace PathfindingDemo.Gameplay.Util;
internal class RaycastHit
{
    private bool hit;
    private Position? hitPosition;

    public bool Hit { get => hit;  }
    public Position HitPosition { get => hitPosition ?? throw new Exception("The raycast didn't hit anything"); }

    public RaycastHit()
    {
        hitPosition = null;
        hit = false;
    }

    public RaycastHit(Position _hitPosition)
    {
        hitPosition = _hitPosition;
        hit = true;
    }
}
