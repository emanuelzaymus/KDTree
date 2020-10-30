using GeodeticPDA.Model;
using System.Collections.Generic;

namespace GeodeticPDA.DataGeneration
{
    class PreparedData
    {
        public static ICollection<Property> GetPreparedProperties()
        {
            return new[] {
                new Property(125, "PROP-A", new GpsCoordinates(1, 2)),
                new Property(185, "PROP-B", new GpsCoordinates(1, 4)),
                new Property(196, "PROP-C", new GpsCoordinates(3, 1)),
                new Property(174, "PROP-D", new GpsCoordinates(10, 20)),
                new Property(133, "PROP-E", new GpsCoordinates(5, 4)),
                new Property(195, "PROP-F", new GpsCoordinates(1, 4)),
            };
        }

        public static ICollection<Parcel> GetPreparedParcels()
        {
            return new[] {
                new Parcel(985, "PARC-M", new GpsCoordinates(1, 2)),
                new Parcel(962, "PARC-N", new GpsCoordinates(1, 4)),
                new Parcel(932, "PARC-O", new GpsCoordinates(5, -10)),
                new Parcel(974, "PARC-P", new GpsCoordinates(3, 1)),
            };
        }

    }
}
