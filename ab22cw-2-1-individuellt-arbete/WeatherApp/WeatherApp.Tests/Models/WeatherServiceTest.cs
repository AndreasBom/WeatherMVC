using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApp.Domain.Repositories;
using WeatherApp.Domain.WebServices;
using WeatherApp.Domain.Services;

namespace WeatherApp.Tests.Models
{
    [TestClass]
    public class WeatherServiceTest
    {
        [TestMethod]
        public void FirstTest()
        {
           var weatherService = new WeatherService(new WeatherRepository(), new WeatherWebService());
            var geo = weatherService.GetLocation("Göteborg");
            //var forcast = weatherService.RefreshForcasts(geo.Location);

            Assert.IsNotNull(geo);
        }
    }
}
