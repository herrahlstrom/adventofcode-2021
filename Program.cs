using adventofcode_2021.Days;

var days = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(s => s.GetTypes())
    .Where(t => t.IsClass)
    .Where(p => typeof(IDay).IsAssignableFrom(p))
    .Select(Activator.CreateInstance).OfType<IDay>().ToArray();


Console.WriteLine("                               +--------------+--------------+");
Console.WriteLine("                               |        FIRST |       SECOND |");
Console.WriteLine("+------------------------------+--------------+--------------+");

foreach (IDay day in days)
{
    object? firstResult;
    object? secondResult;

    await day.ReadInput();

    try
    {
        firstResult = await day.FirstPart();
    }
    catch (NotImplementedException)
    {
        firstResult = null;
    }

    try
    {
        secondResult = await day.SecondPart();
    }
    catch (NotImplementedException)
    {
        secondResult = null;
    }

    Console.WriteLine("| {0:00} {1,-25} | {2,12} | {3,12} |", day.Day, day.Name, firstResult, secondResult);
    Console.WriteLine("+------------------------------+--------------+--------------+");
}

Console.WriteLine();