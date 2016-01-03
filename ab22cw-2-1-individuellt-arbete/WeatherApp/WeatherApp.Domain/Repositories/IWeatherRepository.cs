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
        IEnumerable<Weather> GetWeathers();
        Weather GetWeather(int id);
        void AddWeather(Weather weather);
        void UpdateWeather(Weather weather);
        void DeleteWeather(int id);

        IEnumerable<Location> GetLocations();
        Location GetLocation(int id);
        Location GetLocation(string location);
        void AddLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(int id);
        void Save();
    }


    //public interface IWeatherRepository : IDisposable
    //{   
    //    IEnumerable<Forcast> GetForcasts();
    //    Forcast GetForcast(int id);
    //    void AddForcast(Forcast forcast);
    //    void UpdateForcast(Forcast forcast);
    //    void DeleteForcast(int id);

    //    IEnumerable<GeoLocation> GetGeoLocations();
    //    GeoLocation GetGeoLocation(int id);
    //    GeoLocation GetGeoLocation(string location);
    //    void AddGeoLocation(GeoLocation geoLocation);
    //    void UpdateGeoLocation(GeoLocation geoLocation);
    //    void DeleteGeoLocation(int id);
    //    void Save();
    //}
}
