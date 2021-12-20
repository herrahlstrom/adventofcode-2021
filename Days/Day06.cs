namespace adventofcode_2021.Days;

internal class Day06 : IDay
{
    private int[] _initValues = Array.Empty<int>();
    public int Day => 6;
    public string Name => "Lanternfish";

    public long FirstPart() => SimulateDays(80);

    public void ReadInput()
    {
        _initValues = File
            .ReadAllText("Input/06.txt")
            .Split(',').Select(int.Parse).ToArray();
    }

    public long SecondPart() => SimulateDays(256);

    private long SimulateDays(int days)
    {
        long[] values = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        foreach (int n in _initValues)
        {
            values[n]++;
        }

        for (int d = 1; d <= days; d++)
        {
            long born = values[0];
            values[0] = values[1];
            values[1] = values[2];
            values[2] = values[3];
            values[3] = values[4];
            values[4] = values[5];
            values[5] = values[6];
            values[6] = values[7] + born;
            values[7] = values[8];
            values[8] = born;
        }

        return values.Sum();
    }
}