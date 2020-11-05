﻿using GeodeticPDA.DataGeneration;
using GeodeticPDA.Model;
using System;
using System.Collections.Generic;

namespace GeodeticPDA.Presenter
{
    public class GeodeticPdaPresenter
    {
        private readonly GeodeticPdaSystem _pdaSystem = new GeodeticPdaSystem();

        public void Populate(string propertiesCount, string parcelsCount)
        {
            int? properties = GetInt(propertiesCount);
            int? parcels = GetInt(parcelsCount);
            if (properties.HasValue && parcels.HasValue)
            {
                RandomDataGenerator generator = new RandomDataGenerator(properties.Value, parcels.Value);
                _pdaSystem.Populate(generator.PreparedProperties, generator.PreparedParels);
            }
        }

        public void PopulateWithPreparedData()
        {
            var randomProperties = PreparedData.GetPreparedProperties();
            var randomParcels = PreparedData.GetPreparedParcels();
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

        public ICollection<Parcel> FindParcels(string latitudeStr, string longitudeStr)
        {
            var gps = GetGpsCoordinates(latitudeStr, longitudeStr);
            if (gps != null)
            {
                return _pdaSystem.FindParcels(gps);
            }
            return new Parcel[0];
        }

        public ICollection<Parcel> FindParcels(string latitudeStr, string longitudeStr,
            string latitude2Str, string longitude2Str)
        {
            var gps = GetGpsCoordinates(latitudeStr, longitudeStr);
            var gps2 = GetGpsCoordinates(latitude2Str, longitude2Str);
            if (gps != null && gps2 != null)
            {
                return _pdaSystem.FindParcels(gps, gps2);
            }
            return new Parcel[0];
        }

        public ICollection<GpsLocationObject> FindAll(string latitudeStr, string longitudeStr)
        {
            var gps = GetGpsCoordinates(latitudeStr, longitudeStr);
            if (gps != null)
            {
                return _pdaSystem.FindAll(gps);
            }
            return new GpsLocationObject[0];
        }

        public ICollection<GpsLocationObject> FindAll(string latitudeStr, string longitudeStr,
            string latitude2Str, string longitude2Str)
        {
            var gps = GetGpsCoordinates(latitudeStr, longitudeStr);
            var gps2 = GetGpsCoordinates(latitude2Str, longitude2Str);
            if (gps != null && gps2 != null)
            {
                return _pdaSystem.FindAll(gps, gps2);
            }
            return new GpsLocationObject[0];
        }

        public void Save(UserInputData userInputData)
        {
            if (userInputData is PropertyInputData propertyInputData)
            {
                if (propertyInputData.IsNew)
                    AddProperty(propertyInputData);
                else
                    EditProperty(propertyInputData);
            }
            else if (userInputData is ParcelInputData parcelInputData)
            {
                if (parcelInputData.IsNew)
                    AddParcel(parcelInputData);
                else
                    EditParcel(parcelInputData);
            }
        }

        private void AddProperty(PropertyInputData propertyInputData)
        {
            int? number = GetInt(propertyInputData.Number);
            var coordinates = GetGpsCoordinates(propertyInputData.GpsLatitude, propertyInputData.GpsLongitude);

            if (number.HasValue && coordinates != null)
            {
                var newProperty = new Property(number.Value, propertyInputData.Description, coordinates);
                _pdaSystem.AddProperty(newProperty);
                Console.WriteLine("Property added.");
            }
            else Console.WriteLine("Property was not added.");
        }

        private void AddParcel(ParcelInputData parcelInputData)
        {
            int? number = GetInt(parcelInputData.Number);
            var coordinates = GetGpsCoordinates(parcelInputData.GpsLatitude, parcelInputData.GpsLongitude);

            if (number.HasValue && coordinates != null)
            {
                var newParcel = new Parcel(number.Value, parcelInputData.Description, coordinates);
                _pdaSystem.AddParcel(newParcel);
                Console.WriteLine("Parcel added.");
            }
            else Console.WriteLine("Parcel was not added.");
        }

        private void EditProperty(PropertyInputData propertyInputData)
        {
            int? number = GetInt(propertyInputData.Number);
            var coordinates = GetGpsCoordinates(propertyInputData.GpsLatitude, propertyInputData.GpsLongitude);

            if (number.HasValue && coordinates != null)
            {
                _pdaSystem.EditProperty(propertyInputData.OriginalObject,
                    number.Value, propertyInputData.Description, coordinates);
                Console.WriteLine("Property edited.");
            }
            else Console.WriteLine("Property was not edited.");
        }

        private void EditParcel(ParcelInputData parcelInputData)
        {
            int? number = GetInt(parcelInputData.Number);
            var coordinates = GetGpsCoordinates(parcelInputData.GpsLatitude, parcelInputData.GpsLongitude);

            if (number.HasValue && coordinates != null)
            {
                _pdaSystem.EditParcel(parcelInputData.OriginalObject,
                    number.Value, parcelInputData.Description, coordinates);
                Console.WriteLine("Parcel edited.");
            }
            else Console.WriteLine("Parcel was not edited.");
        }

        public void Remove(UserInputData userInputData)
        {
            if (userInputData is PropertyInputData propertyInputData)
            {
                _pdaSystem.RemoveProperty(propertyInputData.OriginalObject);
                Console.WriteLine("Property removed.");
            }
            else if (userInputData is ParcelInputData parcelInputData)
            {
                _pdaSystem.RemoveParcel(parcelInputData.OriginalObject);
                Console.WriteLine("Parcel removed.");
            }
        }

        private GpsCoordinates GetGpsCoordinates(string latitudeStr, string longitudeStr)
        {
            if (double.TryParse(latitudeStr, out double latitude) && double.TryParse(longitudeStr, out double longitude))
            {
                return new GpsCoordinates(latitude, longitude);
            }
            return null;
        }

        private int? GetInt(string number)
        {
            if (int.TryParse(number, out int ret))
            {
                return ret;
            }
            return null;
        }

    }
}
