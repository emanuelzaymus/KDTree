using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticPDA
{
    abstract class GpsLocation
    {
        public GpsCoordinates Coordinates { get; set; }

        protected GpsLocation(GpsCoordinates coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
