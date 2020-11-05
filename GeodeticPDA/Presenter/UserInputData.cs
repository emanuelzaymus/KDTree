using GeodeticPDA.Model;

namespace GeodeticPDA.Presenter
{
    /// <summary>
    /// Input data from user.
    /// </summary>
    abstract public class UserInputData
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public string GpsLatitude { get; set; }
        public string GpsLongitude { get; set; }
        /// <summary>
        /// Either Parcels for Property or Properties for Parcel.
        /// </summary>
        public object[] RelatedObjects { get; protected set; } = new object[0];

        /// <summary>
        /// If it is edited object or newly created object.
        /// </summary>
        public bool IsNew { get; }

        protected UserInputData(GpsLocationObject gpsLocationObject)
        {
            Number = gpsLocationObject.Number.ToString();
            Description = gpsLocationObject.Description;
            GpsLatitude = gpsLocationObject.Coordinates.Latitude.ToString();
            GpsLongitude = gpsLocationObject.Coordinates.Longitude.ToString();
            IsNew = false;
        }

        public UserInputData()
        {
            IsNew = true;
        }

    }
}
