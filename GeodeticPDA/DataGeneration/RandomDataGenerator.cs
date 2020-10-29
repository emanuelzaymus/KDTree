using GeodeticPDA.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeodeticPDA.DataGeneration
{
    class RandomDataGenerator
    {
        public static IEnumerable<Property> GenerateProperties(int count)
        {
            var r = new Random();
            for (int i = 0; i < count; i++) yield return GenerateProperty(r);
        }

        public static IEnumerable<Parcel> GenerateParcels(int count)
        {
            var r = new Random();
            for (int i = 0; i < count; i++) yield return GenerateParcel(r);
        }

        private static Property GenerateProperty(Random r)
        {
            return new Property(r.Next(), "PROP-" + RandomString(r), GenerateGpsCoordinates(r));
        }

        private static Parcel GenerateParcel(Random r)
        {
            return new Parcel(r.Next(), "PARC-" + RandomString(r), GenerateGpsCoordinates(r));
        }

        private static GpsCoordinates GenerateGpsCoordinates(Random r)
        {
            return new GpsCoordinates(RandomDouble(r), RandomDouble(r));
        }

        private static string RandomString(Random r)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, r.Next(4, 10)).Select(s => s[r.Next(s.Length)]).ToArray());
        }

        private static double RandomDouble(Random r) => r.NextDouble() * r.Next();

    }
}
