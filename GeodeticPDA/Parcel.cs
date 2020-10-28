using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticPDA
{
    class Parcel : GpsLocation
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public List<Property> Properties { get; set; }

        public Parcel(int number, string description, List<Property> properties, GpsCoordinates coordinates) : base(coordinates)
        {
            Number = number;
            Description = description;
            Properties = properties;
        }
    }
}
