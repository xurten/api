using GoogleMaps.LocationServices;
using GpsLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsLibrary
{
    public interface GpsApi
    {
        GpsPoint GetGpsLocationFromAddress(string city, string address);
    }
}
