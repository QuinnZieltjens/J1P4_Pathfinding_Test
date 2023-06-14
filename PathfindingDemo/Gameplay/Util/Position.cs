namespace PathfindingDemo.Gameplay.Util;
internal class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int _x, int _y)
    {
        X = _x;
        Y = _y;
    }

    /// <summary>
    /// gives a position with the value <c>0, 0</c>
    /// </summary>
    public static Position Zero => new(0, 0);

    /// <summary>
    /// gives a position with the value <c>0, 1</c>
    /// </summary>
    public static Position Up => new(0, 1);

    /// <summary>
    /// gives a position with the value <c>0, -1</c>
    /// </summary>
    public static Position Down => new(0, -1);

    /// <summary>
    /// gives a position with the value <c>-1, 0</c>
    /// </summary>
    public static Position Left => new(-1, 0);

    /// <summary>
    /// gives a position with the value <c>1, 0</c>
    /// </summary>
    public static Position Right => new(1, 0);


    public static implicit operator Position((int x, int y) _pos) => new(_pos.x, _pos.y);
    public static Position operator -(Position _a, Position _b) => new(_a.X - _b.X, _a.Y - _b.Y);
    public static Position operator +(Position _a, Position _b) => new(_a.X + _b.X, _a.Y + _b.Y);
    public static Position operator *(Position _a, Position _b) => new(_a.X * _b.X, _a.Y * _b.Y);
    public static Position operator /(Position _a, Position _b) => new(_a.X / _b.X, _a.Y / _b.Y);
    public static Position operator *(Position _a, int _b) => new(_a.X * _b, _a.Y * _b);
}
