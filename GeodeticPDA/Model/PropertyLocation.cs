namespace GeodeticPDA.Model
{
    public class PropertyLocation : Property
    {
        /// <summary>
        /// Location of <c>Property</c>.
        /// </summary>
        public PropertyLocation(GpsCoordinates coordinates) : base(coordinates)
        {
        }
    }
}
