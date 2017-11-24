using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsLibrary.Model
{
    public class GpsAddress
    {
        public string City { set; get; }
        public string Address { set; get; }

        public GpsAddress(AddressData addressData)
        {
            City = addressData.City;
            Address = addressData.Address;
        }

    }
}
