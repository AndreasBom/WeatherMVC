using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;
using WeatherApp.Domain.Models;
using WeatherApp.Domain.WebServices;

namespace WeatherApp.Mocks
{
    public class WeatherWebServiceMock : IWeatherWebService
    {
        public IEnumerable<Weather> GetForcast(double latitude, double longitude)
        {
            string rawJsonString;
            var physicalPath = 
                @"C:\Users\Andre\Documents\Copy\Skola\Linneuniversitetet\ASP MVC\Project\ab22cw-2-1-individuellt-arbete\WeatherApp\WeatherApp\App_Data\data.json";
                //Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "data.json");

            using (var reader = new StreamReader(physicalPath))
            {
                rawJsonString = reader.ReadToEnd();
            }

            var jObj = JObject.Parse(rawJsonString);

            return jObj["timeseries"].Select(item => new Weather(item)).ToList();
        }
    }
}
