namespace PathfindingDemo.Gameplay.Util;

internal struct Position
{
    public int X { get; }
    public int Y { get; }

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


    public static Position operator -(Position _a, Position _b) => new(_a.X - _b.X, _a.Y - _b.Y);
    public static Position operator +(Position _a, Position _b) => new(_a.X + _b.X, _a.Y + _b.Y);
    public static Position operator *(Position _a, Position _b) => new(_a.X * _b.X, _a.Y * _b.Y);
    public static Position operator /(Position _a, Position _b) => new(_a.X / _b.X, _a.Y / _b.Y);
    public static Position operator *(Position _a, int _b) => new(_a.X * _b, _a.Y * _b);
}
