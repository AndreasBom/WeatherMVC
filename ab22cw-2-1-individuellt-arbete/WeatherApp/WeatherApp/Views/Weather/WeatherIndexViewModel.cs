using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services.Description;
using WeatherApp.Domain.Models;
using WeatherApp.Domain.Repositories;
using WeatherApp.Domain.Services;
using WeatherApp.Domain.WebServices;


namespace WeatherApp.Views.Weather
{
    public class WeatherIndexViewModel
    {
        private readonly IWeatherService _weatherService;
        

        public WeatherIndexViewModel()
        {
            _weatherService = new WeatherService(new WeatherRepository(), new WeatherWebService());

        }

        public WeatherIndexViewModel(IWeatherRepository repository, IWeatherWebService webservice)
        {
            _weatherService = new WeatherService(repository, webservice);
        }

        [Required(ErrorMessage = "Skriv in en plats")]
        [DisplayName("Sök väder")]
        public string LocationInput { get; set; }

        public Location LocationObject => _weatherService.GetLocation(LocationInput);
        public string DayOfWeekToday
        {
            get
            {
                var culture = new System.Globalization.CultureInfo("sv-SE");
                return culture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            }
        }

        //Get day from date
        public string DayOfWeek(DateTime date)
        {
            var culture = new System.Globalization.CultureInfo("sv-SE");
            return culture.DateTimeFormat.GetDayName(date.DayOfWeek);
        }

        public IEnumerable<Domain.Models.Weather> Weather
        {
            get
            {
                _weatherService.UpdateWeather(LocationObject);
                var location = _weatherService.GetLocation(LocationInput);

                return FilterWeather(location.WeatherForcasts);
            }
        }

        //takes a list of weather objects and returns one object per day for 5 days
        private IEnumerable<Domain.Models.Weather> FilterWeather(ICollection<Domain.Models.Weather> weatherList)
        {
            var filteredList = (from weather in weatherList
                                where weather.ValidTime > DateTime.Now
                                && weather.ValidTime.Hour == 12
                                select weather).Take(5).ToList();

            if (DateTime.Now.Hour > 12)
            {
                filteredList.Add((from weather in weatherList
                                  where weather.ValidTime > DateTime.Now
                                  select weather).FirstOrDefault());
            }

            return filteredList.OrderBy(a => a.ValidTime).Take(5).ToList();
        }

    }
}
