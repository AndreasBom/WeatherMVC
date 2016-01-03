using System;
using System.Collections;
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
            var locationObj = _webservice.GetLocation(location);
            var locationInDatabase = _repository.GetLocationByPlaceId(locationObj.PlaceId);

            if (locationInDatabase == null)
            {
                _repository.AddLocation(locationObj);
                _repository.Save();
            }
            return _repository.GetLocationByPlaceId(locationObj.PlaceId);
        }

        public override void UpdateWeather(Location location)
        {
            if (location.WeatherForcasts != null)
            {
                if (location.WeatherForcasts.Any() == false ||
                   location.WeatherForcasts.Select(w => w.NextUpdate).FirstOrDefault() < DateTime.Now)
                {
                    foreach (var weather in location.WeatherForcasts.ToList())
                    {
                        _repository.DeleteWeather(weather.WeatherId);
                    }
                }
            }

            foreach (var weather in _webservice.GetWeather(location))
            {
                weather.NextUpdate = DateTime.Now.AddMinutes(15);
                _repository.AddWeather(weather);
            }


            _repository.Save();
        }


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
