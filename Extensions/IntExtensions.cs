namespace adventofcode_2021.Extensions;

internal static class IntExtensions
{
    public static bool Between(this int value, int a, int b)
    {
        return value >= a && value <= b ||
               value >= b && value <= a;
    }
}