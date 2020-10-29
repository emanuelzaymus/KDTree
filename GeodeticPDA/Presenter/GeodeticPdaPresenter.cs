using GeodeticPDA.DataGeneration;
using GeodeticPDA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeodeticPDA.Presenter
{
    public class GeodeticPdaPresenter
    {
        private readonly GeodeticPdaSystem _pdaSystem = new GeodeticPdaSystem();

        public GpsLocationObject choosedObject { get; set; }

        public void Populate()
        {
            var randomProperties = RandomDataGenerator.GenerateProperties(1000);
            var randomParcels = RandomDataGenerator.GenerateParcels(1000);
            _pdaSystem.Populate(randomProperties, randomParcels);
        }

        public ICollection<Property> FindProperties(string latitudeStr, string longitudeStr)
        {
            var gps = GetGpsCoordinates(latitudeStr, longitudeStr);
            if (gps != null)
            {
                return _pdaSystem.FindProperties(gps);
            }
            return new Property[0];
        }

        public ICollection<Property> FindProperties(string latitudeStr, string longitudeStr,
            string latitude2Str, string longitude2Str)
        {
            var gps = GetGpsCoordinates(latitudeStr, longitudeStr);
            var gps2 = GetGpsCoordinates(latitude2Str, longitude2Str);
            if (gps != null && gps2 != null)
            {
                return _pdaSystem.FindProperties(gps, gps2);
            }
            return new Property[0];
        }

        private GpsCoordinates GetGpsCoordinates(string latitudeStr, string longitudeStr)
        {
            if (double.TryParse(latitudeStr, out double latitude) && double.TryParse(longitudeStr, out double longitude))
            {
                return new GpsCoordinates(latitude, longitude);
            }
            return null;
        }

    }
}
