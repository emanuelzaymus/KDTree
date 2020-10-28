using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticPDA
{
    class GpsCoordinates
    {
        public char Latitude { get; set; }
        public double LatitudeCoordinate { get; set; }
        public char Longitude { get; set; }
        public double LongitudeCoordinate { get; set; }

        public GpsCoordinates(char latitude, double latitudeCoordinate, char longitude, double longitudeCoordinate)
        {
            Latitude = latitude;
            LatitudeCoordinate = latitudeCoordinate;
            Longitude = longitude;
            LongitudeCoordinate = longitudeCoordinate;
        }
    }
}
