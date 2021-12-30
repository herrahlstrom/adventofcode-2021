using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode_2021.Days
{
    internal class Day19:IDay
    {
        private List<Scanner> scanners = new();
        public int Day => 19;
        public string Name => "Beacon Scanner";
        public object FirstPart()
        {


            throw new NotImplementedException();
        }

        public void ReadInput()
        {
            using var reader = new StreamReader("Input/19.txt");

            var scannerLineRz = new Regex(@"--- scanner (\d+) ---$");

            Scanner? current = null;
            while (!reader.EndOfStream && reader.ReadLine() is { } line)
            {
                if (line == "")
                {
                    current = null;
                }else if (current is null)
                {
                    Match m;
                    if((m = scannerLineRz.Match(line)).Success == false)
                    {
                        throw new InvalidDataException("Invalid scanner head: " + line);
                    }

                    current = new Scanner()
                    {
                        Id = int.Parse(m.Groups[1].Value)
                    };
                    scanners.Add(current);
                }
                else
                {
                    int[] values = line.Split(',').Select(int.Parse).ToArray();
                    current.Beacons.Add(new Beacon(){ X = values[0] , Y = values[1] , Z = values[2] });
                }
            }
        }

        public object SecondPart() => throw new NotImplementedException();

        class Scanner
        {
            public int Id { get; init; }
            public List<Beacon> Beacons { get; } = new();
        }

        record Beacon
        {
            public int X { get; init; }
            public int Y { get; init; }
            public int Z { get; init; }

            public double GetDistance(Beacon other)
            {
                return Math.Sqrt(Math.Pow(other.X - X, 2) + 
                                 Math.Pow(other.Y - Y, 2) +
                                 Math.Pow(other.Z - Z, 2));
            }
        }
    }
}
