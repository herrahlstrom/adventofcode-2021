namespace adventofcode_2021.Days;

internal class Day01 : IDay
{
    private string? _input;

    int IDay.Day => 1;

    string IDay.Name => "Sonar sweep";

    public object FirstPart()
    {
        using var reader = new StringReader(_input ?? throw new InvalidOperationException("Input is not initialized"));

        int result = 0;

        int lastValue = int.MaxValue;
        while (reader.ReadLine() is { } line)
        {
            int value = int.Parse(line);
            if (value > lastValue)
            {
                result++;
            }

            lastValue = value;
        }

        return result;
    }

    public void ReadInput()
    {
        _input = File.ReadAllText("Input/01.txt");
    }

    public object SecondPart()
    {
        using var reader = new StringReader(_input ?? throw new InvalidOperationException("Input is not initialized"));

        int[] sliding = { 0, 0, 0 };
        int result = 0;

        sliding[1] = int.Parse(reader.ReadLine() ?? throw new InvalidDataException());
        sliding[0] = int.Parse(reader.ReadLine() ?? throw new InvalidDataException());

        int lastSum = int.MaxValue;
        while (reader.ReadLine() is { } line)
        {
            int value = int.Parse(line);

            sliding[2] = sliding[1];
            sliding[1] = sliding[0];
            sliding[0] = value;

            int sum = sliding.Sum();

            if (sum > lastSum)
            {
                result++;
            }

            lastSum = sum;
        }

        return result;
    }
}