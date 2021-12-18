namespace adventofcode_2021.Models;

internal struct Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; init; }
    public int Y { get; init; }

    public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);
}