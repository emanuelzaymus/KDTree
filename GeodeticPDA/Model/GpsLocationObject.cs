using System.Collections.Generic;
using System.Linq;

namespace GeodeticPDA.Model
{
    public abstract class GpsLocationObject : ICsvSerializable
    {
        private readonly int _id;
        public int Number { get; set; }
        public string Description { get; set; }
        public GpsCoordinates Coordinates { get; set; }

        protected GpsLocationObject(int id, int number, string description, GpsCoordinates coordinates)
        {
            _id = id;
            Number = number;
            Description = description;
            Coordinates = coordinates;
        }

        protected GpsLocationObject(string[] csvData)
        {
            _id = int.Parse(csvData[0]);
            Number = int.Parse(csvData[1]);
            Description = csvData[2];
            Coordinates = new GpsCoordinates(csvData.ToList().GetRange(3, 2).ToArray());
        }

        public virtual string ToCsv(char d)
        {
            return $"{_id}{d}{Number}{d}{Description}{d}{Coordinates.ToCsv(d)}";
        }

        public override string ToString()
        {
            return $"Num:{Number}, Desc:{Description}, Coor:[{Coordinates}]";
        }

        public override bool Equals(object obj)
        {
            return obj is GpsLocationObject gpsLocationObject &&
                   _id == gpsLocationObject._id &&
                   Number == gpsLocationObject.Number &&
                   Description == gpsLocationObject.Description &&
                   EqualityComparer<GpsCoordinates>.Default.Equals(Coordinates, gpsLocationObject.Coordinates);
        }

        public override int GetHashCode()
        {
            int hashCode = -23422471;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<GpsCoordinates>.Default.GetHashCode(Coordinates);
            return hashCode;
        }

    }
}
