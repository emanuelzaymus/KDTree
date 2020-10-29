namespace GeodeticPDA.Model
{
    public class ParcelLocation : Parcel
    {
        public ParcelLocation(GpsCoordinates coordinates) : base(0, null, coordinates)
        {
        }
    }
}
