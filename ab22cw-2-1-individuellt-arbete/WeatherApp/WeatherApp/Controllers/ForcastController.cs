using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Domain.Repositories;
using WeatherApp.Domain.Services;
using WeatherApp.Domain.WebServices;
using WeatherApp.Mocks;

namespace WeatherApp.Controllers
{
    [RequireHttps]
    public class ForcastController : Controller
    {
        private readonly IWeatherService _weatherService;


        public ForcastController()
        {
            
        }

        public ForcastController(WeatherService service)
        {
            _weatherService = service;
        }

        // GET: Forcast
        public ActionResult Index()
        {
            var webservice = new WeatherService(new WeatherRepository(), new WeatherWebService());

            var locaction = webservice.GetLocation("Göteborg");
            var forcast = webservice.GetWeather(locaction);

            return View();
        }
    }
}