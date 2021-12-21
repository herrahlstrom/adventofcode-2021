namespace adventofcode_2021.Days;

internal class Day11 : IDay
{
    private readonly List<int> _levels = new();
    private Point _end;
    public int Day => 11;
    public string Name => "Dumbo Octopus";

    public object FirstPart()
    {
        int[] levels = _levels.ToArray();
        long flashCount = 0;

        for (int step = 1; step <= 100; step++)
        {
            flashCount += StepLoop(levels);
        }

        return flashCount;
    }

    public void ReadInput()
    {
        using var reader = new StreamReader("Input/11.txt");

        int y = 0;
        while (!reader.EndOfStream && reader.ReadLine() is { } line)
        {
            _levels.AddRange(line.Select(c => c - 48));

            _end = new Point(y, line.Length - 1);
            y++;
        }
    }

    public object SecondPart()
    {
        int[] levels = _levels.ToArray();

        for (int step = 1;; step++)
        {
            StepLoop(levels);
            if (levels.All(c => c == 0))
            {
                return step;
            }
        }
    }

    private IEnumerable<Point> GetAdjacents(Point p)
    {
        return new[]
        {
            p + Point.Up,
            p + Point.Up + Point.Right,
            p + Point.Right,
            p + Point.Right + Point.Down,
            p + Point.Down,
            p + Point.Down + Point.Left,
            p + Point.Left,
            p + Point.Left + Point.Up
        }.Where(p => p.X >= 0 && p.X <= _end.X && p.Y >= 0 && p.Y <= _end.Y);
    }

    private int GetIndex(Point p) => p.Y * (_end.X + 1) + p.X;

    private Point GetPoint(int n) => new(n % (_end.X + 1), n / (_end.X + 1));

    private long StepLoop(IList<int> levels)
    {
        var flashes = new HashSet<int>();

        for (int i = 0; i < levels.Count; i++)
        {
            levels[i]++;
        }

        bool done = false;
        while (!done)
        {
            done = true;
            for (int i = 0; i < levels.Count; i++)
            {
                if (levels[i] > 9 && flashes.Add(i))
                {
                    done = false;
                    Point p = GetPoint(i);
                    foreach (Point adjacent in GetAdjacents(p))
                    {
                        levels[GetIndex(adjacent)]++;
                    }
                }
            }
        }

        foreach (int i in flashes)
        {
            levels[i] = 0;
        }

        return flashes.Count;
    }
}