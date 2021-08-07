using System.Collections.Generic;

namespace GeodeticPDA.Model
{
    public class Parcel : GpsLocationObject
    {
        private static int _nextParcelId = -1;

        public List<Property> Properties { get; } = new List<Property>();

        public Parcel(int number, string description, GpsCoordinates coordinates)
            : base(_nextParcelId--, number, description, coordinates)
        {
        }

        /// <summary>
        /// Creates <c>Parcel</c> from CSV file values.
        /// </summary>
        /// <param name="csvData">One line from CSV file - Splitted values</param>
        public Parcel(string[] csvData) : base(csvData)
        {
            int id = int.Parse(csvData[0]);
            if (id <= _nextParcelId)
            {
                _nextParcelId = id - 1;
            }
        }

        /// <summary>
        /// Constructor only for decsendant <c>ParcelPosition</c>.
        /// </summary>
        protected Parcel(GpsCoordinates coordinates) : base(0, 0, null, coordinates) { }

        /// <summary>
        /// Gets comparers for dimensional comparing Parcels bases on their <c>GpsCoordinates</c> location.
        /// </summary>
        /// <returns><c>Parcel</c> comparers array</returns>
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
                   EqualityComparer<List<Property>>.Default.Equals(Properties, parcel.Properties);
        }

    }
}
