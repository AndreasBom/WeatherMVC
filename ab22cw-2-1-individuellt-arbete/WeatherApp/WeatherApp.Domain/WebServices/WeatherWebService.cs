using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.WebServices
{
    public class WeatherWebService : IWeatherWebService
    {
        private static readonly string baseApiUrl = @"http://opendata-download-metfcst.smhi.se/";

        /// <summary>
        /// Gets weather for a specified area
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Returns a list with forcast objects</returns>
        public IEnumerable<Weather> GetWeather(Location location)
        {
            string rawJsonString;
            string lat = location.Latitude.ToString().Substring(0, 8);
            string lng = location.Longitude.ToString().Substring(0, 8);

            var requestUrl = $@"api/category/pmp2g/version/2/geotype/point/lon/{lng}/lat/{lat}/data.json";

            var requestUrlParse = requestUrl.Replace(",", ".");
            var request = (HttpWebRequest)WebRequest.Create($"{baseApiUrl}{requestUrlParse}");

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJsonString = reader.ReadToEnd();
            }

            var jObj = JObject.Parse(rawJsonString);

            return jObj["timeSeries"].Select(item => new Weather(item, location)).ToList();
        }




        public Location GetLocation(string location)
        {
            GeoLocationWebService geoWebservice = new GeoLocationWebService();

            return geoWebservice.AddressToCoordinates(location);
        }


    }


}
