using System.Collections.Generic;

namespace DataStructure.Tests.RandomDataGenerator.TestClasses
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

        public static Comparer<Town>[] GetComparers()
        {
            var xComparer = Comparer<Town>.Create((t1, t2) => t1.X.CompareTo(t2.X));
            var yComparer = Comparer<Town>.Create((t1, t2) => t1.Y.CompareTo(t2.Y));
            return new Comparer<Town>[] { xComparer, yComparer };
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
            int hashCode = 1764330041;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

    }
}
