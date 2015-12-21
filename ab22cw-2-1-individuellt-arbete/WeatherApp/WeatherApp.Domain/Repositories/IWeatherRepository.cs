using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Repositories
{
    public interface IWeatherRepository : IDisposable
    {   
        IEnumerable<Forcast> GetForcasts();
        Forcast GetForcast(int id);
        void AddForcast(Forcast forcast);
        void UpdateForcast(Forcast forcast);
        void DeleteForcast(int id);

        IEnumerable<GeoLocation> GetGeoLocations();
        GeoLocation GetGeoLocation(int id);
        GeoLocation GetGeoLocation(string location);
        void AddGeoLocation(GeoLocation geoLocation);
        void UpdateGeoLocation(GeoLocation geoLocation);
        void DeleteGeoLocation(int id);
        void Save();
    }
}
