using GeodeticPDA.Model;

namespace GeodeticPDA.Presenter
{
    abstract public class UserInputData
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public string GpsLatitude { get; set; }
        public string GpsLongitude { get; set; }
        public object[] RelatedObjects { get; protected set; } = new object[0];

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
