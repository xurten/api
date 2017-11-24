using System;
using System.Collections.Generic;
using GoogleMaps.LocationServices;
using GpsLibrary;
using GpsLibrary.Exceptions;
using GpsLibrary.Model;
using NUnit.Framework;

namespace GpsTests
{
    [TestFixture]
    public class GpsTests
    {
        [Test]
        [TestCase(53.0382334, 18.690583, "Torun", "Katarzynki 23")]
        [TestCase(53.0295739, 18.6332549, "Torun", "Jaworskich 6")]
        [TestCase(53.01726, 11.55785, "Gummern 14", "Schnackenburg")]
        public void ShouldCompereGoodLocations(double latitude, double longitude, string city, string address)
        {
            //given
            GpsApi gpsApi = new GpsGoogleOperation();
            //when
            var gpsLocalization = gpsApi.GetGpsLocationFromAddress(city, address);
            //then
            Assert.AreEqual(latitude, gpsLocalization.Latitude);
            Assert.AreEqual(longitude, gpsLocalization.Longitude);
        }

        [Test]
        public void ShouldCompareLocationsWhenCityIsEmpty()
        {
            //given
            var addresses = new AddressData() { City = "", Address = "Katarzynki 23" };
            GpsApi gpsApi = new GpsGoogleOperation();
            //when
            Assert.Throws<AddressException>(() => gpsApi.GetGpsLocationFromAddress(addresses.City, addresses.Address), "City cannot be empty");
        }

        [Test]
        public void ShouldCompareLocationsWhenCityIsNull()
        {
            //given
            var addresses = new AddressData() { City = null, Address = "Katarzynki 23" };
            GpsApi gpsApi = new GpsGoogleOperation();
            //when
            Assert.Throws<AddressException>(() => gpsApi.GetGpsLocationFromAddress(addresses.City, addresses.Address), "City cannot be null");
        }

        [Test]
        public void ShouldCompareLocationsWhenCityIsWrong()
        {
            //given
            var addresses = new AddressData() { City = "abc", Address = "Katarzynki 23" };
            GpsApi gpsApi = new GpsGoogleOperation();
            //when
            Assert.Throws<AddressException>(() => gpsApi.GetGpsLocationFromAddress(addresses.City, addresses.Address),"Bad city name" );
        }
    }
}
