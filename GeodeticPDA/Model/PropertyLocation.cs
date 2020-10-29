namespace GeodeticPDA.Model
{
    public class PropertyLocation : Property
    {
        public PropertyLocation(GpsCoordinates coordinates) : base(0, null, coordinates)
        {
        }
    }
}
