using System.Collections.Generic;

namespace GeodeticPDA.Model
{
    public class Parcel : GpsLocationObject
    {
        private static int _nextParcelId = -1;

        public HashSet<Property> Properties { get; } = new HashSet<Property>();

        public Parcel(int number, string description, GpsCoordinates coordinates)
            : base(_nextParcelId--, number, description, coordinates)
        {
        }

        // Only for ParcelPosition
        protected Parcel(GpsCoordinates coordinates) : base(0, 0, null, coordinates) { }

        public static Comparer<Parcel>[] GetComparers()
        {
            var latitudeComparer = Comparer<Parcel>.Create((x, y) => x.Coordinates.Latitude.CompareTo(y.Coordinates.Latitude));
            var longitudeComparer = Comparer<Parcel>.Create((x, y) => x.Coordinates.Longitude.CompareTo(y.Coordinates.Longitude));
            return new[] { latitudeComparer, longitudeComparer };
        }

        public override string ToString()
        {
            return $"PARCEL {base.ToString()}";
        }

        public override bool Equals(object obj)
        {
            return obj is Parcel parcel &&
                   base.Equals(obj) &&
                   EqualityComparer<HashSet<Property>>.Default.Equals(Properties, parcel.Properties);
        }

        public override int GetHashCode()
        {
            int hashCode = -1493574510;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<HashSet<Property>>.Default.GetHashCode(Properties);
            return hashCode;
        }
    }
}
