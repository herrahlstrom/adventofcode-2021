﻿using System.Text.RegularExpressions;
using adventofcode_2021.Extensions;

namespace adventofcode_2021.Days;

internal class Day17 : IDay
{
    private int _targetBottom;
    private int _targetLeft;
    private int _targetRight;
    private int _targetTop;

    public int Day => 17;
    public string Name => "Trick Shot";

    public object FirstPart()
    {
        int best = int.MinValue;

        foreach (Point velocity in GetStartVelocities())
        {
            var probe = new Probe
            {
                Position = new Point(0, 0),
                Velocity = velocity
            };

            int highestY = int.MinValue;

            while (true)
            {
                probe.Step();

                if (CanHitTarget(probe) == false)
                {
                    break;
                }

                if (probe.Position.Y > highestY)
                {
                    highestY = probe.Position.Y;
                }

                if (OnTarget(probe))
                {
                    if (highestY > best)
                    {
                        best = highestY;
                    }

                    break;
                }
            }
        }

        return best;
    }

    public void ReadInput()
    {
        string input = File.ReadAllText("Input/17.txt");
        Match rxMatch = Regex.Match(input, @"^target area: x=(\-?\d+)..(\-?\d+), y=(\-?\d+)..(\-?\d+)$");
        if (!rxMatch.Success)
        {
            throw new InvalidDataException();
        }

        int x1 = int.Parse(rxMatch.Groups[1].Value);
        int x2 = int.Parse(rxMatch.Groups[2].Value);
        int y1 = int.Parse(rxMatch.Groups[3].Value);
        int y2 = int.Parse(rxMatch.Groups[4].Value);

        _targetTop = Math.Max(y1, y2);
        _targetBottom = Math.Min(y1, y2);

        _targetLeft = Math.Min(x1, x2);
        _targetRight = Math.Max(x1, x2);
    }

    public object SecondPart()
    {
        HashSet<Point> result = new();

        foreach (Point velocity in GetStartVelocities())
        {
            var probe = new Probe
            {
                Position = new Point(0, 0),
                Velocity = velocity
            };

            while (true)
            {
                probe.Step();

                if (CanHitTarget(probe) == false)
                {
                    break;
                }

                if (OnTarget(probe))
                {
                    result.Add(velocity);
                    break;
                }
            }
        }

        return result.Count;
    }

    private bool CanHitTarget(Probe probe)
    {
        if (probe.Velocity.X < 1 && probe.Position.X < _targetLeft)
        {
            return false;
        }

        if (probe.Position.Y < _targetBottom)
        {
            return false;
        }

        return true;
    }

    private IEnumerable<Point> GetStartVelocities()
    {
        for (int y = _targetBottom - 1; y < 100; y++)
        {
            for (int x = 1; x <= _targetRight; x++)
            {
                yield return new Point(x, y);
            }
        }
    }

    private bool OnTarget(Probe probe)
    {
        return probe.Position.X.Between(_targetLeft, _targetRight) &&
               probe.Position.Y.Between(_targetTop, _targetBottom);
    }

    private class Probe
    {
        public Point Position { get; set; }
        public Point Velocity { get; set; }

        public void Step()
        {
            var velocityDelta = new Point
            {
                X = -Math.Sign(Velocity.X),
                Y = -1
            };

            Position += Velocity;
            Velocity += velocityDelta;
        }
    }
}