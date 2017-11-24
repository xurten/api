using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
