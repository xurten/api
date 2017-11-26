using GpsLibrary.Model;

namespace GpsLibrary
{
    public interface IGpsApi
    {
        GpsPoint GetGpsLocationFromAddress(string city, string address);
    }
}
