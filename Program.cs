using System.Diagnostics;
using adventofcode_2021.Days;

var days = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(s => s.GetTypes())
    .Where(t => t.IsClass)
    .Where(p => typeof(IDay).IsAssignableFrom(p))
    .Select(Activator.CreateInstance).OfType<IDay>()
    .OrderBy(x => x.Day).ToArray();

#if DEBUG
days = days.Skip(days.Length - 1).ToArray();
#endif

long[,] results = new long[25, 3];

var sw = Stopwatch.StartNew();
Parallel.ForEach(days, day =>
{
    var swDay = Stopwatch.StartNew();

    day.ReadInput();

    try
    {
        results[day.Day - 1, 0] = day.FirstPart();
    }
    catch (NotImplementedException) { }

    try
    {
        results[day.Day - 1, 1] = day.SecondPart();
    }
    catch (NotImplementedException) { }

    swDay.Stop();
    results[day.Day - 1, 2] = swDay.ElapsedMilliseconds;
});
sw.Stop();

Console.WriteLine("                               +----------------+----------------+");
Console.WriteLine("                               |          FIRST |         SECOND |");
Console.WriteLine("+------------------------------+----------------+----------------+------------+");

foreach (IDay day in days)
{
    Console.WriteLine("| {0:00} {1,-25} | {2,14} | {3,14} | {4,7} ms |", day.Day, day.Name, results[day.Day - 1, 0],
        results[day.Day - 1, 1], results[day.Day - 1, 2]);
    Console.WriteLine("+------------------------------+----------------+----------------+------------+");
}

Console.WriteLine("                                                                 | {0,7} ms |",
    sw.ElapsedMilliseconds);
Console.WriteLine("                                                                 +------------+");

Console.WriteLine();