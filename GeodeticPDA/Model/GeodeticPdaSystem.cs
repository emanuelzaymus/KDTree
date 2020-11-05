using DataStructures.KDTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GeodeticPDA.Model
{
    /// <summary>
    /// Main system for Geodetic PDA software.
    /// </summary>
    public class GeodeticPdaSystem
    {
        private const char Delimiter = ',';

        private readonly KDTree<Property> _properties = new KDTree<Property>(Property.GetComparers());
        private readonly KDTree<Parcel> _parcels = new KDTree<Parcel>(Parcel.GetComparers());

        /// <summary>
        /// Populates the system with <paramref name="properties"/> and <paramref name="parcels"/>.
        /// </summary>
        /// <param name="properties">Properties to add</param>
        /// <param name="parcels">Parcels to add</param>
        public void Populate(IEnumerable<Property> properties, IEnumerable<Parcel> parcels)
        {
            _properties.AddRange(properties.ToArray());
            _parcels.AddRange(parcels.ToArray());

            foreach (var currProperty in properties)
            {
                AttachProperty(currProperty);
            }
        }

        /// <summary>
        /// Finds all properties on <paramref name="coordinates"/>.
        /// </summary>
        public ICollection<Property> FindProperties(GpsCoordinates coordinates)
        {
            return FindProperties(coordinates, coordinates);
        }

        /// <summary>
        /// Finds all properties between <paramref name="lowerCoordinates"/> position and <paramref name="upperCoordinates"/> position.
        /// </summary>
        public ICollection<Property> FindProperties(GpsCoordinates lowerCoordinates, GpsCoordinates upperCoordinates)
        {
            return _properties.FindRange(new PropertyLocation(lowerCoordinates), new PropertyLocation(upperCoordinates));
        }

        /// <summary>
        /// Finds all parcels on <paramref name="coordinates"/>.
        /// </summary>
        public ICollection<Parcel> FindParcels(GpsCoordinates coordinates)
        {
            return FindParcels(coordinates, coordinates);
        }

        /// <summary>
        /// Finds all parcels between <paramref name="lowerCoordinates"/> position and <paramref name="upperCoordinates"/> position.
        /// </summary>
        public ICollection<Parcel> FindParcels(GpsCoordinates lowerCoordinates, GpsCoordinates upperCoordinates)
        {
            return _parcels.FindRange(new ParcelLocation(lowerCoordinates), new ParcelLocation(upperCoordinates));
        }

        /// <summary>
        /// Finds all objects on <paramref name="coordinates"/>.
        /// </summary>
        public List<GpsLocationObject> FindAll(GpsCoordinates coordinates)
        {
            return FindAll(coordinates, coordinates);
        }

        /// <summary>
        /// Finds all objects between <paramref name="lowerCoordinates"/> position and <paramref name="upperCoordinates"/> position.
        /// </summary>
        public List<GpsLocationObject> FindAll(GpsCoordinates lowerCoordinates, GpsCoordinates upperCoordinates)
        {
            var properties = FindProperties(lowerCoordinates, upperCoordinates);
            var parcels = FindParcels(lowerCoordinates, upperCoordinates);
            var gpsLocationObjects = new List<GpsLocationObject>(properties.Count + parcels.Count);
            gpsLocationObjects.AddRange(properties);
            gpsLocationObjects.AddRange(parcels);
            return gpsLocationObjects;
        }

        /// <summary>
        /// Adds <paramref name="newProperty"/> with creating dependancies on it's parcels.
        /// </summary>
        public void AddProperty(Property newProperty)
        {
            _properties.Add(newProperty);
            AttachProperty(newProperty);
        }

        /// <summary>
        /// Adds <paramref name="newParcel"/> with creating dependancies on it's properties.
        /// </summary>
        public void AddParcel(Parcel newParcel)
        {
            _parcels.Add(newParcel);
            AttachParcel(newParcel);
        }

        /// <summary>
        /// Update <paramref name="editedProperty"/> with <paramref name="newNumber"/>, <paramref name="newDescription"/> and <paramref name="newCoordinates"/>.
        /// </summary>
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

        /// <summary>
        /// Update <paramref name="editedParcel"/> with <paramref name="newNumber"/>, <paramref name="newDescription"/> and <paramref name="newCoordinates"/>.
        /// </summary>
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

        /// <summary>
        /// Removes <paramref name="propertyToRemove"/> with deleting all dependancies on it's parcels.
        /// </summary>
        public void RemoveProperty(Property propertyToRemove)
        {
            // Detach the propertyToRemove
            foreach (var parcel in propertyToRemove.Parcels)
            {
                parcel.Properties.Remove(propertyToRemove);
            }
            _properties.Remove(propertyToRemove);
        }

        /// <summary>
        /// Removes <paramref name="parcelToRemove"/> with deleting all dependancies on it's properties.
        /// </summary>
        public void RemoveParcel(Parcel parcelToRemove)
        {
            // Detach the parcelToRemove
            foreach (var property in parcelToRemove.Properties)
            {
                property.Parcels.Remove(parcelToRemove);
            }
            _parcels.Remove(parcelToRemove);
        }

        /// <summary>
        /// Exports all properties into <paramref name="fileName"/> file.
        /// </summary>
        /// <param name="fileName">CSV file path name</param>
        internal void SavePropertiesToFile(string fileName) => WriteToFile(_properties, fileName);

        /// <summary>
        /// Exports all parcels into <paramref name="fileName"/> file.
        /// </summary>
        /// <param name="fileName">CSV file path name</param>
        internal void SaveParcelsToFile(string fileName) => WriteToFile(_parcels, fileName);

        /// <summary>
        /// Imports properties from <paramref name="fileName"/> file if it exists.
        /// </summary>
        /// <param name="fileName">CSV file path name</param>
        internal void LoadPropertiesFromFile(string fileName) => LoadFromFile(fileName, words => AddProperty(new Property(words)));

        /// <summary>
        /// Imports parcels from <paramref name="fileName"/> file if it exists.
        /// </summary>
        /// <param name="fileName">CSV file path name</param>
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
