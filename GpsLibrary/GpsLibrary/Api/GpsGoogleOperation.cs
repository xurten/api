using GoogleMaps.LocationServices;
using GpsLibrary.Exceptions;
using GpsLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsLibrary
{
    public class GpsGoogleOperation : GpsApi
    {
        public GpsPoint GetGpsLocationFromAddress(string city, string address)
        {
            if (string.IsNullOrEmpty(city))
                throw new AddressException("City cannot be null or empty");
            if (string.IsNullOrEmpty(address))
                throw new AddressException("Address cannot be null or empty");
            var gls = new GoogleLocationService(ApiConst.API_KEY);
            var addressData = new AddressData() { City = city, Address = address };
            var gpsPoint = gls.GetLatLongFromAddress(addressData);
            if (gpsPoint == null) throw new AddressException("Bad city or address");
            return new GpsPoint(gpsPoint);
        }
    }
}