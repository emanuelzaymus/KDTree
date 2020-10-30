using GeodeticPDA.Model;
using System;

namespace GeodeticPDA.Presenter
{
    public class UserInputDataFactory
    {
        public static UserInputData GetUserInputData(object gpsLocationObject)
        {
            if (gpsLocationObject is Property property)
            {
                return new PropertyInputData(property);
            }
            else if (gpsLocationObject is Parcel parcel)
            {
                return new ParcelInputData(parcel);
            }
            throw new ArgumentException(
                $"Parameter {nameof(gpsLocationObject)} must be of type GpsLocationObject!");
        }
    }
}
