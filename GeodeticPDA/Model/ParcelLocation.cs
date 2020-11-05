namespace GeodeticPDA.Model
{
    public class ParcelLocation : Parcel
    {
        /// <summary>
        /// Location of <c>Parcel</c>.
        /// </summary>
        public ParcelLocation(GpsCoordinates coordinates) : base(coordinates)
        {
        }
    }
}
