namespace GeodeticPDA.Model
{
    public class GpsCoordinates : ICsvSerializable
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GpsCoordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public GpsCoordinates(string[] csvData)
        {
            Latitude = double.Parse(csvData[0]);
            Longitude = double.Parse(csvData[1]);
        }

        public string ToCsv(char d)
        {
            return $"{Latitude}{d}{Longitude}";
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

    }
}
