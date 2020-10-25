using DataStructure.Tests.RandomDataGenerator.TestClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Tests.RandomDataGenerator
{
    public class RandomDataGenerator
    {
        private static readonly Random random = new Random(1234);

        public static Town GenerateTown()
        {
            return new Town(RandomString(10), RandomInt(), RandomInt());
        }

        public static IEnumerable<Town> GenerateTowns(int count)
        {
            for (int i = 0; i < count; i++) yield return GenerateTown();
        }

        public static TownPosition GenerateTownPosition()
        {
            return new TownPosition(RandomInt(), RandomInt());
        }

        public static Point3D GeneratePoint3D()
        {
            return new Point3D(RandomString(15), RandomDouble(), RandomDouble(), RandomDouble());
        }

        public static IEnumerable<Point3D> GeneratePoints3D(int count)
        {
            for (int i = 0; i < count; i++) yield return GeneratePoint3D();
        }

        public static Point3DPosition GeneratePoint3DPosition()
        {
            return new Point3DPosition(RandomDouble(), RandomDouble(), RandomDouble());
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static int RandomInt() => random.Next(int.MinValue, int.MaxValue);

        private static double RandomDouble() => random.NextDouble() * RandomInt();
    }
}
