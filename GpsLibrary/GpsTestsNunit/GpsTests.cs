using GpsLibrary;
using GpsLibrary.Exceptions;
using GpsTestsNunit.Mocks;
using NUnit.Framework;

namespace GpsTests
{

    /*
     *Napisz bibliotekę w C#, która na podstawie danych wejściowych (miasto, ulica) zwróci współrzędne geograficzne
     *przypisane do tego adresu. Do solucji dołącz Unit Tests, który przetestuje kod.
     * */

    [TestFixture]
    public class GpsTests
    {
        private readonly IGpsApi gpsApi;

        public GpsTests()
        {
            gpsApi = GpsMock.GetGpsApiMock();
        }

        [Test]
        [TestCase(53.0382334, 18.690583, "Torun", "Katarzynki 23")]
        [TestCase(53.0295739, 18.6332549, "Torun", "Jaworskich 6")]
        [TestCase(53.01726, 11.55785, "Gummern 14", "Schnackenburg")]
        public void ShouldCompereGoodLocations(double latitude, double longitude, string city, string address)
        {
            var gpsLocalization = gpsApi.GetGpsLocationFromAddress(city, address);
            Assert.AreEqual(latitude, gpsLocalization.Latitude);
            Assert.AreEqual(longitude, gpsLocalization.Longitude);
        }

        [Test]
        [TestCase("", "Katarzynki 23")]
        public void ShouldCompareLocationsWhenCityIsEmpty(string city, string address)
        {
            Assert.Throws<AddressException>(() => gpsApi.GetGpsLocationFromAddress(city, address));
        }

        [Test]
        [TestCase(null, "Katarzynki 23")]
        public void ShouldCompareLocationsWhenCityIsNull(string city, string address)
        {
            Assert.Throws<AddressException>(() => gpsApi.GetGpsLocationFromAddress(city, address), "City cannot be null");
        }

        [Test]
        [TestCase("abc", "Katarzynki 23")]
        public void ShouldCompareLocationsWhenCityIsWrong(string city, string address)
        {
            Assert.Throws<AddressException>(() => gpsApi.GetGpsLocationFromAddress(city, address), "Bad city name");
        }
    }
}
