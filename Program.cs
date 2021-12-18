using System.Diagnostics;
using adventofcode_2021.Days;

IDay day = new Day01();

try
{
    var sw = Stopwatch.StartNew();
    object firstResult = await day.FirstPart();
    sw.Stop();
    Console.WriteLine("First part: {0}, {1:N0}ms", firstResult, sw.ElapsedMilliseconds);

    sw.Restart();
    object secondResult = await day.SecondPart();
    sw.Stop();
    Console.WriteLine("Second part: {0}, {1:N0}ms", secondResult, sw.ElapsedMilliseconds);
}
catch (NotImplementedException) { }