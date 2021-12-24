namespace adventofcode_2021.Extensions;

internal static class PointExtensions
{
    public static IEnumerable<Point> GetNeighbours(this Point p, bool diagonally = false)
    {
        yield return p + Point.Up;
        yield return p + Point.Right;
        yield return p + Point.Down;
        yield return p + Point.Left;

        if (diagonally)
        {
            yield return p + Point.Up + Point.Right;
            yield return p + Point.Right + Point.Down;
            yield return p + Point.Down + Point.Left;
            yield return p + Point.Left + Point.Up;
        }
    }
}