﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Domain.Models;
using WeatherApp.Domain.WebServices;
using WeatherApp.Mocks;

namespace WeatherApp.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var w = new WeatherWebServiceMock();
            var geo = new GeoLocation();
            var data = w.GetForcast(geo);
            return View();
        }


        public ActionResult About()
        {
            
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}