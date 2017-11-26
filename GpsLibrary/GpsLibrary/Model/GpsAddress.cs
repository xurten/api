using GoogleMaps.LocationServices;

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
