using DataStructures.KDTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GeodeticPDA.Model
{
    public class GeodeticPdaSystem
    {
        private const char Delimiter = ',';

        private readonly KDTree<Property> _properties = new KDTree<Property>(Property.GetComparers());
        private readonly KDTree<Parcel> _parcels = new KDTree<Parcel>(Parcel.GetComparers());

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
                editedProperty.Parcels.Clear();
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
                editedParcel.Properties.Clear();
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

        internal void SavePropertiesToFile(string fileName) => WriteToFile(_properties, fileName);

        internal void SaveParcelsToFile(string fileName) => WriteToFile(_parcels, fileName);

        internal void LoadPropertiesFromFile(string fileName) => LoadFromFile(fileName, words => AddProperty(new Property(words)));

        internal void LoadParcelsFromFile(string fileName) => LoadFromFile(fileName, words => AddParcel(new Parcel(words)));

        private void WriteToFile(IEnumerable<ICsvSerializable> csvSerializables, string fileName)
        {
            var builder = new StringBuilder(csvSerializables.Count() * 35); // 35 should be average of length of one line 
            foreach (var item in csvSerializables)
            {
                builder.AppendLine(item.ToCsv(Delimiter));
            }
            File.WriteAllText(fileName, builder.ToString());
        }

        private void LoadFromFile(string fileName, Action<string[]> addObject)
        {
            if (File.Exists(fileName))
            {
                using StreamReader streamReader = File.OpenText(fileName);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] words = line.Split(Delimiter);
                    addObject(words);
                }
            }
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
