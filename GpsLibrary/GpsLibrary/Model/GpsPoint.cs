using GoogleMaps.LocationServices;

namespace GpsLibrary.Model
{
    public class GpsPoint
    {
        public double Latitude { set; get; }
        public double Longitude { set; get; }

        public GpsPoint(MapPoint mapPoint)
        {
            Latitude = mapPoint.Latitude;
            Longitude = mapPoint.Longitude;
        }
    }
}
