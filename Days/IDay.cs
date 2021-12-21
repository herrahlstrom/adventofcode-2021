namespace adventofcode_2021.Days;

internal interface IDay
{
    int Day { get; }
    string Name { get; }
    object FirstPart();
    void ReadInput();
    object SecondPart();
}