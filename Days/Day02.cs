﻿namespace adventofcode_2021.Days;

internal class Day02 : IDay
{
    private string? _input;

    int IDay.Day => 2;

    string IDay.Name => "Dive";

    public async Task<long> FirstPart()
    {
        using var reader = new StringReader(_input ?? throw new InvalidOperationException("Input is not initialized"));

        Point pos = new(0, 0);

        while (await reader.ReadLineAsync() is { } line)
        {
            string[] arr = line.Split();
            string command = arr[0];
            int value = int.Parse(arr[1]);

            pos += command switch
            {
                "forward" => new Point(value, 0),
                "down" => new Point(0, value),
                "up" => new Point(0, -value),
                _ => throw new NotImplementedException()
            };
        }

        return pos.X * pos.Y;
    }

    public async Task ReadInput()
    {
        _input = await File.ReadAllTextAsync("Days/Input/02.txt");
    }

    public async Task<long> SecondPart()
    {
        using var reader = new StringReader(_input ?? throw new InvalidOperationException("Input is not initialized"));

        Point pos = new(0, 0);
        int aim = 0;

        while (await reader.ReadLineAsync() is { } line)
        {
            string[] arr = line.Split();
            string command = arr[0];
            int value = int.Parse(arr[1]);

            switch (command)
            {
                case "forward":
                    pos += new Point(value, value * aim);
                    break;
                case "down":
                    aim += value;
                    break;
                case "up":
                    aim -= value;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        return pos.X * pos.Y;
    }
}