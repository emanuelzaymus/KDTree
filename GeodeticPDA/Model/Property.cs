using System.Collections.Generic;

namespace GeodeticPDA.Model
{
    class Property : GpsLocationObject
    {
        private static int _nextPropertyId = 1;

        public List<Parcel> Parcels { get; } = new List<Parcel>(); // Set ?

        public Property(int number, string description, GpsCoordinates coordinates)
            : base(_nextPropertyId++, number, description, coordinates)
        {
        }

        public static Comparer<Property>[] GetComparers()
        {
            var latitudeComparer = Comparer<Property>.Create((x, y) => x.Coordinates.Latitude.CompareTo(y.Coordinates.Latitude));
            var longitudeComparer = Comparer<Property>.Create((x, y) => x.Coordinates.Longitude.CompareTo(y.Coordinates.Longitude));
            return new[] { latitudeComparer, longitudeComparer };
        }

        public override string ToString()
        {
            return $"PROPERTY {base.ToString()}";
        }

        public override bool Equals(object obj)
        {
            return obj is Property property &&
                   base.Equals(obj) &&
                   EqualityComparer<List<Parcel>>.Default.Equals(Parcels, property.Parcels);
        }

        public override int GetHashCode()
        {
            int hashCode = -326724672;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Parcel>>.Default.GetHashCode(Parcels);
            return hashCode;
        }
    }
}
