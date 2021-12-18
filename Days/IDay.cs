namespace adventofcode_2021.Days;

internal interface IDay
{
    int Day { get; }
    string Name { get; }
    Task<long> FirstPart();
    Task ReadInput();
    Task<long> SecondPart();
}