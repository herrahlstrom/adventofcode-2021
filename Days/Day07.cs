namespace adventofcode_2021.Days;

internal class Day07 : IDay
{
    private int[] _positions = Array.Empty<int>();

    private readonly Dictionary<int, int> _stepCost = new()
    {
        { 1, 1 }
    };

    public int Day => 7;
    public string Name => "The Treachery of Whales";

    public long FirstPart()
    {
        int min = _positions.Min();
        int max = _positions.Max();

        int bestCost = int.MaxValue;
        for (int targetPos = min; targetPos <= max; targetPos++)
        {
            int cost = 0;
            foreach (int crabPos in _positions)
            {
                if (crabPos > targetPos)
                {
                    cost += crabPos - targetPos;
                }
                else if (crabPos < targetPos)
                {
                    cost += targetPos - crabPos;
                }

                if (cost > bestCost)
                {
                    break;
                }
            }

            if (cost < bestCost)
            {
                bestCost = cost;
            }
        }

        return bestCost;
    }

    public void ReadInput()
    {
        _positions = File
            .ReadAllText("Input/07.txt")
            .Split(',').Select(int.Parse).ToArray();
    }

    public long SecondPart()
    {
        int min = _positions.Min();
        int max = _positions.Max();

        int bestCost = int.MaxValue;
        for (int targetPos = min; targetPos <= max; targetPos++)
        {
            int cost = 0;
            foreach (int crabPos in _positions)
            {
                int steps;
                if (crabPos > targetPos)
                {
                    steps = crabPos - targetPos;
                }
                else if (crabPos < targetPos)
                {
                    steps = targetPos - crabPos;
                }
                else
                {
                    continue;
                }

                cost += GetStepCost(steps);

                if (cost > bestCost)
                {
                    break;
                }
            }

            if (cost < bestCost)
            {
                bestCost = cost;
            }
        }

        return bestCost;

        int GetStepCost(int step)
        {
            if (step < 1)
            {
                return 0;
            }

            if (_stepCost.TryGetValue(step, out int cost))
            {
                return cost;
            }

            cost = GetStepCost(step - 1) + step;
            _stepCost[step] = cost;
            return cost;
        }
    }
}