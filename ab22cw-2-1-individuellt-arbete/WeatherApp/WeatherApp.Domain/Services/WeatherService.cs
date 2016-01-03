using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Models;
using WeatherApp.Domain.Repositories;
using WeatherApp.Domain.WebServices;

namespace WeatherApp.Domain.Services
{
    public class WeatherService : WeatherServiceBase
    {
        private readonly IWeatherRepository _repository;
        private readonly IWeatherWebService _webservice;

        public WeatherService(IWeatherRepository repository, IWeatherWebService webservice)
        {
            _repository = repository;
            _webservice = webservice;
        }


        public override Location GetLocation(string location)
        {
            var geoLocation = _webservice.GetLocation(location);
            _repository.AddLocation(geoLocation);
            _repository.Save();
            return geoLocation;
        }

        public override ICollection<Weather> GetWeather(Location location)
        {
            var forcasts = _webservice.GetWeather(location);

            foreach (var forcast in forcasts)
            {
                _repository.AddWeather(forcast);
                _repository.Save();
            }
            return (ICollection<Weather>) forcasts;
        }






        //public override GeoLocation GetLocation(string location)
        //{
        //    var geoLocation = _webservice.LookUpGeoLocation(location);

        //    //var geoLocation = _repository.GetGeoLocation(location);

        //    //if (geoLocation == null)
        //    //{
        //    //    geoLocation = _webservice.LookUpGeoLocation(location);
        //    //    _repository.AddGeoLocation(geoLocation);
        //    //    _repository.Save();
        //    //}
        //    return geoLocation;
        //}

        //public override void RefreshForcasts(GeoLocation location)
        //{


        //    if (location.Forcasts == null || !location.Forcasts.Any() ||
        //        location.Forcasts.Select(l => l.NextUpdate).FirstOrDefault() < DateTime.Now)
        //    {
        //        foreach (var forcast in location.Forcasts)
        //        {
        //            _repository.DeleteForcast(location.GeoLocationId);
        //        }

        //        foreach (var forcast in _webservice.GetForcast(location))
        //        {
        //            forcast.NextUpdate = DateTime.Now.AddMinutes(10);
        //            _repository.AddForcast(forcast);
        //        }

        //        _repository.Save();
        //    }
        //}
    }
}
