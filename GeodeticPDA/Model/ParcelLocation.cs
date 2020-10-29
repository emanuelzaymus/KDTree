namespace GeodeticPDA.Model
{
    class ParcelLocation : Parcel
    {
        public ParcelLocation(GpsCoordinates coordinates) : base(0, null, coordinates)
        {
        }
    }
}
