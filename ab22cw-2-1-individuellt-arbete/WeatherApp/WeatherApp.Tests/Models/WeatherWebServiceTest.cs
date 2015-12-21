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
    public class WeatherWebServiceTest
    {
        WeatherWebServiceMock wMock;

        [TestInitialize]
        public void SetUp()
        {
            // Arrange
            wMock = new WeatherWebServiceMock();
        }


        [TestMethod]
        public void GetForcast_FetchJsonDataIsNotNull()
        {
            // Act
            IEnumerable<Forcast> request = null;
            request = wMock.GetForcast(new GeoLocation());

            // Assert
            Assert.IsNotNull(request);
        }
        [TestMethod]
        public void GetForcast_AssertFirstSetOfData()
        {
        //Arrange
            //Expected values
            DateTime validTime = Convert.ToDateTime("2015-12-17 15:00:00");
            float t = 3.6f;
            var tstm = 0;
            int tcc_mean = 8;
			string pcat = (Preciptation.Drizzle).ToString();

            //Actual values
            var data = wMock.GetForcast(new GeoLocation());
            var setOfData = (from s in data
                select s).FirstOrDefault();
        //Assert
            Assert.AreEqual(validTime, setOfData.ValidTime);
            Assert.AreEqual(t, setOfData.Temperature);
            Assert.AreEqual(tstm, setOfData.ThunderProbability);
            Assert.AreEqual(tcc_mean, setOfData.CloudFactor);
            Assert.AreEqual(pcat, setOfData.Preciptation.ToString());
        }
    }
}
