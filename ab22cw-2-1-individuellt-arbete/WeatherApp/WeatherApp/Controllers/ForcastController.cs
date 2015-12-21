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

            var x = new WeatherService(new WeatherRepository(), new WeatherWebService());
            var t = x.GetLocation("Malmö");
            string xx = "";
            //try
            //{

            //}
            //catch (Exception ex)
            //{
            //    while (ex.InnerException != null)
            //    {
            //        ex = ex.InnerException;
            //    }
            //    FlashMessage.Danger(ex.Message);
            //}

            return View();
        }
    }
}