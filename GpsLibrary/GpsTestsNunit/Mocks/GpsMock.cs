using GoogleMaps.LocationServices;
using GpsLibrary;
using GpsLibrary.Exceptions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace GpsTestsNunit.Mocks
{
    public class GpsMock
    {
        public static IGpsApi GetGpsApiMock()
        {
            var gpsApi = Substitute.For<IGpsApi>();
            MapPoint mapPoint = new MapPoint();
            mapPoint.Latitude = 53.0382334;
            mapPoint.Longitude = 18.690583;
            gpsApi.GetGpsLocationFromAddress("Torun", "Katarzynki 23").Returns(new GpsLibrary.Model.GpsPoint(mapPoint));
            mapPoint.Latitude = 53.0295739;
            mapPoint.Longitude = 18.6332549;
            gpsApi.GetGpsLocationFromAddress("Torun", "Jaworskich 6").Returns(new GpsLibrary.Model.GpsPoint(mapPoint));
            mapPoint.Latitude = 53.01726;
            mapPoint.Longitude = 11.55785;
            gpsApi.GetGpsLocationFromAddress("Gummern 14", "Schnackenburg").Returns(new GpsLibrary.Model.GpsPoint(mapPoint));
            gpsApi.GetGpsLocationFromAddress("", "Katarzynki 23").Throws(new AddressException());
            gpsApi.GetGpsLocationFromAddress(null, "Katarzynki 23").Throws(new AddressException("City cannot be null"));
            gpsApi.GetGpsLocationFromAddress("abc", "Katarzynki 23").Throws(new AddressException("Bad city name"));

            return gpsApi;
        }
    }
}
