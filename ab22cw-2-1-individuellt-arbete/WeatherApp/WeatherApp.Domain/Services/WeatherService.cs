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

        public WeatherService()
            : this(new WeatherRepository(), new WeatherWebService())
        {
            //Empty!
        }

        public WeatherService(IWeatherRepository repository, IWeatherWebService webservice)
        {
            _repository = repository;
            _webservice = webservice;
        }


        /// <summary>
        /// Looks up lat and lng from google geocode, based on a location name.
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Location object</returns>
        public override Location GetLocation(string location)
        {
            Location locationObj;

            try
            {
                locationObj = _webservice.GetLocation(location);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            var locationInDatabase = _repository.GetLocationByPlaceId(locationObj.PlaceCode);

            if (locationInDatabase == null)
            {
                _repository.AddLocation(locationObj);
                _repository.Save();
            }

            return _repository.GetLocationByPlaceId(locationObj.PlaceCode);
        }



        /// <summary>
        /// Updates weather to Location object
        /// 
        /// Returns true if fetched from webservice and false if fetched from database
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <returns>bool</returns>
        public override void UpdateWeather(Location location)
        {
            
            if (location.WeatherForcasts == null ||
                location.WeatherForcasts.Any() == false ||
               location.WeatherForcasts.Select(w => w.NextUpdate).FirstOrDefault() < DateTime.Now)
            {
                if (location.WeatherForcasts != null)
                {
                    foreach (var weather in location.WeatherForcasts.ToList())
                    {
                        _repository.DeleteWeather(weather.WeatherId);
                    }
                }

                foreach (var weather in _webservice.GetWeather(location))
                {
                    weather.NextUpdate = DateTime.Now.AddMinutes(15);
                    _repository.AddWeather(weather);
                    
                }
                _repository.Save();
            }
        }

        public override IEnumerable<Location> GetAllLocations()
        {
            return _repository.GetLocations();
        }

    }
}
