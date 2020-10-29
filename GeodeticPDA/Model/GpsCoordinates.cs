namespace GeodeticPDA.Model
{
    public class GpsCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GpsCoordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"Lat:{Latitude}, Long:{Longitude}";
        }

        public override bool Equals(object obj)
        {
            return obj is GpsCoordinates coordinates &&
                   Latitude == coordinates.Latitude &&
                   Longitude == coordinates.Longitude;
        }

        public override int GetHashCode()
        {
            int hashCode = -1416534245;
            hashCode = hashCode * -1521134295 + Latitude.GetHashCode();
            hashCode = hashCode * -1521134295 + Longitude.GetHashCode();
            return hashCode;
        }
    }
}
