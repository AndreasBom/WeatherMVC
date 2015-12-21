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
        //TODO Refactor forcast and Geolocation to user same base class

        private static readonly string baseApiUrl = @"http://opendata-download-metfcst.smhi.se";
        
        public IEnumerable<Forcast> GetForcast(GeoLocation geoLocation)
        {
            string rawJsonString;
            string lat = geoLocation.Latitude.ToString("0.000000");
            string lng = geoLocation.Longitude.ToString("0.000000");

            var requestUrl = $@"/api/category/pmp2g/version/1/geopoint/lat/{lat}/lon/{lng}/data.json";
            var requestUrlParse = requestUrl.Replace(",", ".");

            var request = (HttpWebRequest) WebRequest.Create($"{baseApiUrl}{requestUrlParse}");

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJsonString = reader.ReadToEnd();
            }

            var jObj = JObject.Parse(rawJsonString);

            return jObj["timeseries"].Select(item => new Forcast(item, geoLocation)).ToList();
        }

        public GeoLocation LookUpGeoLocation(string location)
        {
            GeoLocationWebService geoWebservice = new GeoLocationWebService();

            return geoWebservice.AddressToCoordinates(location);
        }
    }

    
}
