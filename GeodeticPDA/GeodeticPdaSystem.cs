using DataStructures.KDTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticPDA
{
    class GeodeticPdaSystem
    {
        public KDTree<Property> Properties { get; set; }
        public KDTree<Parcel> Parcels { get; set; }

        public GeodeticPdaSystem(KDTree<Property> properties, KDTree<Parcel> parcels)
        {
            Properties = properties;
            Parcels = parcels;
        }

        public List<Property> FindProperties(GpsCoordinates coordinates)
        {
            throw new NotImplementedException();
        }

        public List<Parcel> FindParcels(GpsCoordinates coordinates)
        {
            throw new NotImplementedException();
        }

        public List<GpsLocation> FindAll(GpsCoordinates coordinates)
        {
            throw new NotImplementedException();
        }

        public void AddProperty(Property property)
        {
            throw new NotImplementedException();
        }

        public void AddParcel(Parcel parcel)
        {
            throw new NotImplementedException();
        }

    }
}
