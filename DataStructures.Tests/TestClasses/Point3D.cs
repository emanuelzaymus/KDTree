using System.Collections.Generic;

namespace DataStructures.Tests.TestClasses
{
    public class Point3D
    {
        public string Label { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(string label, double x, double y, double z)
        {
            Label = label;
            X = x;
            Y = y;
            Z = z;
        }

        public static Comparer<Point3D>[] GetComparers()
        {
            var xComparer = Comparer<Point3D>.Create((p1, p2) => p1.X.CompareTo(p2.X));
            var yComparer = Comparer<Point3D>.Create((p1, p2) => p1.Y.CompareTo(p2.Y));
            var zComparer = Comparer<Point3D>.Create((p1, p2) => p1.Z.CompareTo(p2.Z));
            return new Comparer<Point3D>[] { xComparer, yComparer, zComparer };
        }

        public override string ToString()
        {
            return $"{Label} [{X},{Y},{Z}]";
        }

        public override bool Equals(object obj)
        {
            return obj is Point3D d &&
                   Label == d.Label &&
                   X == d.X &&
                   Y == d.Y &&
                   Z == d.Z;
        }

        public override int GetHashCode()
        {
            int hashCode = 1540734477;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Label);
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }

    }
}
