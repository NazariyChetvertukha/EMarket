using System.Collections.Generic;

namespace WebApp.Services
{
    public interface IGeolocationService
    {
        void SetGeolocation(string geolocation);
        List<string> GetGeolocations();
        void RemoveGeolocation(string geolocation);
    }
}