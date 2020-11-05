using GeodeticPDA.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeodeticPDA.DataGeneration
{
    public class RandomDataGenerator
    {
        public List<Property> PreparedProperties { get; }

        public List<Parcel> PreparedParels { get; }

        public RandomDataGenerator(int propertiesCount, int parcelsCount)
        {
            PreparedProperties = new List<Property>(propertiesCount);
            PreparedParels = new List<Parcel>(parcelsCount);
            PrepareData(propertiesCount, parcelsCount);
        }

        private void PrepareData(int propertiesCount, int parcelsCount)
        {
            var r = new Random();
            GpsCoordinates gpsCoordinates = GenerateGpsCoordinates(r);
            for (int i = 0; i < propertiesCount || i < parcelsCount; i++)
            {
                if (r.NextDouble() < 0.9)
                {
                    gpsCoordinates = GenerateGpsCoordinates(r);
                }
                if (i < parcelsCount)
                {
                    if (r.NextDouble() < 0.2)
                    {
                        gpsCoordinates = GenerateGpsCoordinates(r);
                    }
                    PreparedParels.Add(GenerateParcel(r, gpsCoordinates));
                }
                if (i < propertiesCount)
                {
                    if (r.NextDouble() < 0.2)
                    {
                        gpsCoordinates = GenerateGpsCoordinates(r);
                    }
                    PreparedProperties.Add(GenerateProperty(r, gpsCoordinates));
                }
            }
        }

        private Property GenerateProperty(Random r, GpsCoordinates gpsCoordinates)
        {
            return new Property(r.Next(), "PROP-" + RandomString(r), gpsCoordinates);
        }

        private Parcel GenerateParcel(Random r, GpsCoordinates gpsCoordinates)
        {
            return new Parcel(r.Next(), "PARC-" + RandomString(r), gpsCoordinates);
        }

        private GpsCoordinates GenerateGpsCoordinates(Random r)
        {
            return new GpsCoordinates(RandomDouble(r), RandomDouble(r));
        }

        private string RandomString(Random r)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, r.Next(4, 10)).Select(s => s[r.Next(s.Length)]).ToArray());
        }

        private double RandomDouble(Random r) => r.NextDouble() * r.Next(-10000, 10000);

    }
}
