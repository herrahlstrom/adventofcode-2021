namespace adventofcode_2021.Days;

internal interface IDay
{
    int Day { get; }
    string Name { get; }
    long FirstPart();
    void ReadInput();
    long SecondPart();
}