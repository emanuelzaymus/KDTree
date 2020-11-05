using System.Collections.Generic;

namespace GeodeticPDA.Model
{
    public class Property : GpsLocationObject
    {
        private static int _nextPropertyId = 1;

        public HashSet<Parcel> Parcels { get; } = new HashSet<Parcel>();

        public Property(int number, string description, GpsCoordinates coordinates)
            : base(_nextPropertyId++, number, description, coordinates)
        {
        }

        /// <summary>
        /// Creates <c>Property</c> from CSV file values.
        /// </summary>
        /// <param name="csvData">One line from CSV file - Splitted values</param>
        public Property(string[] csvData) : base(csvData)
        {
            int id = int.Parse(csvData[0]);
            if (id >= _nextPropertyId)
            {
                _nextPropertyId = id + 1;
            }
        }

        /// <summary>
        /// Constructor only for decsendant <c>PropertyPosition</c>.
        /// </summary>
        protected Property(GpsCoordinates coordinates) : base(0, 0, null, coordinates) { }

        /// <summary>
        /// Gets comparers for dimensional comparing Properties bases on their <c>GpsCoordinates</c> location.
        /// </summary>
        /// <returns><c>Property</c> comparers array</returns>
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
                   EqualityComparer<HashSet<Parcel>>.Default.Equals(Parcels, property.Parcels);
        }

        public override int GetHashCode()
        {
            int hashCode = -326724672;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<HashSet<Parcel>>.Default.GetHashCode(Parcels);
            return hashCode;
        }
    }
}
