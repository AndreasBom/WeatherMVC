using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using WeatherApp.Domain.Models;
using WeatherApp.Domain.Repositories;
using WeatherApp.Domain.WebServices;
using WeatherApp.Domain.Services;

namespace WeatherApp.Tests.Models
{
    [TestClass]
    public class WeatherServiceTest
    {
        [TestMethod]
        public void WeatherServiceGetLocationTest()
        {

            var webService = new Domain.WebServices.Fakes.StubIWeatherWebService
            {
                GetLocationString = s => new Location
                {
                    Latitude = 11.1f,
                    Longitude = 22.2f,
                    LocationId = 1,
                    LocationText = "Göteborg",
                    PlaceCode = "abc"
                }
            };

            var repo = new Domain.Repositories.Fakes.StubIWeatherRepository();

            var w = new WeatherService(repo, webService);

            var actual = w.GetLocation("Göteborg");
            
            Assert.AreEqual(actual.LocationText, "Göteborg");
        }
    }
}
