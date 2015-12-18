using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApp.Domain.Models;
using WeatherApp.Mocks;

namespace WeatherApp.Tests.Models
{
    [TestClass]
    public class WeatherWebService
    {
        [TestMethod]
        public void FetchJsonDataIsSuccess()
        {
            // Arrange
            WeatherWebServiceMock wMock = new WeatherWebServiceMock();

            // Act

            IEnumerable<Weather> request = null;
            request = wMock.GetForcast(22.12, 121.12);

            
            // Assert
            Assert.IsNotNull(request);
        }
    }
}
