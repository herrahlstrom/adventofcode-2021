namespace adventofcode_2021.Days;

internal class Day01 : IDay
{
    private string? _input;

    public async Task<long> FirstPart()
    {
        using var reader = new StringReader(_input ?? throw new InvalidOperationException("Input is not initialized"));

        int result = 0;

        int lastValue = int.MaxValue;
        while (await reader.ReadLineAsync() is { } line)
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

    public async Task ReadInput()
    {
        _input = await File.ReadAllTextAsync("Days/Input/01.txt");
    }


    public async Task<long> SecondPart()
    {
        using var reader = new StringReader(_input ?? throw new InvalidOperationException("Input is not initialized"));

        int[] sliding = { 0, 0, 0 };
        int result = 0;

        sliding[1] = int.Parse(await reader.ReadLineAsync() ?? throw new InvalidDataException());
        sliding[0] = int.Parse(await reader.ReadLineAsync() ?? throw new InvalidDataException());

        int lastSum = int.MaxValue;
        while (await reader.ReadLineAsync() is { } line)
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

    int IDay.Day => 1;

    string IDay.Name => "Sonar sweep";
}