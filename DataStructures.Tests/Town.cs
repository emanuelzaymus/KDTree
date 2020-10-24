using System;

namespace DataStructures.Tests
{
    public class Town
    {
        public string Name { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Town(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{Name} [{X},{Y}]";
        }

        public override bool Equals(object obj)
        {
            return obj is Town town &&
                   Name == town.Name &&
                   X == town.X &&
                   Y == town.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, X, Y);
        }

    }
}
