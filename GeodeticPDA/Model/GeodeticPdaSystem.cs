using DataStructures.KDTree;
using System.Collections.Generic;
using System.Linq;

namespace GeodeticPDA.Model
{
    public class GeodeticPdaSystem
    {
        private readonly KDTree<Property> _properties = new KDTree<Property>(Property.GetComparers());
        private readonly KDTree<Parcel> _parcels = new KDTree<Parcel>(Parcel.GetComparers());

        public GeodeticPdaSystem()
        {
        }

        public GeodeticPdaSystem(IEnumerable<Property> properties, IEnumerable<Parcel> parcels)
        {
            Populate(properties, parcels);
        }

        public void Populate(IEnumerable<Property> properties, IEnumerable<Parcel> parcels)
        {
            _properties.AddRange(properties.ToArray());
            _parcels.AddRange(parcels.ToArray());

            foreach (var currProperty in properties)
            {
                AttachProperty(currProperty);
            }
        }

        public ICollection<Property> FindProperties(GpsCoordinates coordinates)
        {
            return FindProperties(coordinates, coordinates);
        }

        public ICollection<Property> FindProperties(GpsCoordinates lowerCoordinates, GpsCoordinates upperCoordinates)
        {
            return _properties.FindRange(new PropertyLocation(lowerCoordinates), new PropertyLocation(upperCoordinates));
        }

        public ICollection<Parcel> FindParcels(GpsCoordinates coordinates)
        {
            return FindParcels(coordinates, coordinates);
        }

        public ICollection<Parcel> FindParcels(GpsCoordinates lowerCoordinates, GpsCoordinates upperCoordinates)
        {
            return _parcels.FindRange(new ParcelLocation(lowerCoordinates), new ParcelLocation(upperCoordinates));
        }

        public List<GpsLocationObject> FindAll(GpsCoordinates coordinates)
        {
            return FindAll(coordinates, coordinates);
        }

        public List<GpsLocationObject> FindAll(GpsCoordinates lowerCoordinates, GpsCoordinates upperCoordinates)
        {
            var properties = FindProperties(lowerCoordinates, upperCoordinates);
            var parcels = FindParcels(lowerCoordinates, upperCoordinates);
            var gpsLocationObjects = new List<GpsLocationObject>(properties.Count + parcels.Count);
            gpsLocationObjects.AddRange(properties);
            gpsLocationObjects.AddRange(parcels);
            return gpsLocationObjects;
        }

        public void AddProperty(Property newProperty)
        {
            _properties.Add(newProperty);
            AttachProperty(newProperty);
        }

        public void AddParcel(Parcel newParcel)
        {
            _parcels.Add(newParcel);
            AttachParcel(newParcel);
        }

        public void EditProperty(Property editedProperty, int newNumber, string newDescription, GpsCoordinates newCoordinates)
        {
            editedProperty.Number = newNumber;
            editedProperty.Description = newDescription;
            if (!editedProperty.Coordinates.Equals(newCoordinates))
            {
                RemoveProperty(editedProperty);
                editedProperty.Coordinates = newCoordinates;
                AddProperty(editedProperty);
            }
        }

        public void EditParcel(Parcel editedParcel, int newNumber, string newDescription, GpsCoordinates newCoordinates)
        {
            editedParcel.Number = newNumber;
            editedParcel.Description = newDescription;
            if (!editedParcel.Coordinates.Equals(newCoordinates))
            {
                RemoveParcel(editedParcel);
                editedParcel.Coordinates = newCoordinates;
                AddParcel(editedParcel);
            }
        }

        public void RemoveProperty(Property propertyToRemove)
        {
            // Detach the propertyToRemove
            foreach (var parcel in propertyToRemove.Parcels)
            {
                parcel.Properties.Remove(propertyToRemove);
            }
            _properties.Remove(propertyToRemove);
        }

        public void RemoveParcel(Parcel parcelToRemove)
        {
            // Detach the parcelToRemove
            foreach (var property in parcelToRemove.Properties)
            {
                property.Parcels.Remove(parcelToRemove);
            }
            _parcels.Remove(parcelToRemove);
        }

        private void AttachProperty(Property newProperty)
        {
            var belongingParcels = FindParcels(newProperty.Coordinates);
            newProperty.Parcels.AddRange(belongingParcels);
            foreach (var parcel in belongingParcels)
            {
                parcel.Properties.Add(newProperty);
            }
        }

        private void AttachParcel(Parcel newParcel)
        {
            var belongingProperties = FindProperties(newParcel.Coordinates);
            newParcel.Properties.AddRange(belongingProperties);
            foreach (var property in belongingProperties)
            {
                property.Parcels.Add(newParcel);
            }
        }

    }
}
