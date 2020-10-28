using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticPDA
{
    class Property : GpsLocation
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public List<Parcel> Parcels { get; set; }

        public Property(int number, string description, List<Parcel> parcels, GpsCoordinates coordinates) : base(coordinates)
        {
            Number = number;
            Description = description;
            Parcels = parcels;
        }
    }
}
