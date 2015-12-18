using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.WebServices
{
    public class WeatherWebService : IWeatherWebService
    {
        private static readonly string baseApiUrl = @"http://opendata-download-metfcst.smhi.se";
        


        public IEnumerable<Weather> GetForcast(double latitude, double longitude)
        {
            string rawJson;

            var requestUrl = $@"/api/category/pmp2g/version/1/geopoint/lat/{latitude}/lon/{longitude}/data.json";
            var requestUrlParse = requestUrl.Replace(",", ".");

            var request = (HttpWebRequest) WebRequest.Create($"{baseApiUrl}{requestUrlParse}");

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJson = reader.ReadToEnd();
            }

            throw new NotImplementedException();
        } 
    }

    
}
