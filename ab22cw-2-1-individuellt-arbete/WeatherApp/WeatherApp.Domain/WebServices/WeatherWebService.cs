using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UtilityForTesting.Util;
using WeatherApp.Domain.Models;


namespace WeatherApp.Domain.WebServices
{
    public class WeatherWebService : IWeatherWebService
    {
        private static readonly string baseApiUrl = @"http://opendata-download-metfcst.smhi.se/";
        public int CacheHeadersMaxAge { get; set; }


        //public IEnumerable<Weather> GetWeather(Location location)
        //{
        //    string la = location.Latitude.ToString("F");
        //    string ln = location.Longitude.ToString("F");
        //    var lat = la.Replace(",", ".");
        //    var lng = ln.Replace(",", ".");


        //    var test = $@"api/category/pmp2g/version/2/geotype/point/lon/{lng}/lat/{lat}/data.json";
        //    var apiUrl = $@"api/category/pmp2g/version/2/geotype/point/lon/12.96/lat/58.26/data.json";
        //    //var newUrl = String.Format()



        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            //Set HTTP header
        //            client.BaseAddress = new Uri(baseApiUrl);
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            //Read the HTTP response
        //            var response = client.GetAsync(test).Result;

        //            //Checks for cache controle max-age and returns an int (minutes)
        //            if (response.Headers.CacheControl != null)
        //            {
        //                if (response.Headers.CacheControl.MaxAge != null)
        //                    CacheHeadersMaxAge = (int)response.Headers.CacheControl.MaxAge.Value.TotalMinutes;
        //            }
        //            else
        //                CacheHeadersMaxAge = 0;

        //            //Ensure status code is 200, else en exception is thrown
        //            response.EnsureSuccessStatusCode();

        //            //Reads the json content
        //            var content = response.Content.ReadAsAsync<JObject>().Result;

        //            return content["timeSeries"].Select(item => new Weather(item, location)).ToList();
        //        }
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        throw new HttpRequestException(e.ToString());
        //    }
        //}




        /// <summary>
        /// Gets weather for a specified area
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Returns a list with forcast objects</returns>
        public IEnumerable<Weather> GetWeather(Location location)
        {
            //TODO STÄDA!!!!

            string lat = location.Latitude.ToString("F");
            string lng = location.Longitude.ToString("F");

            //var lat = la.Replace(",", ".");
            //var lng = ln.Replace(",", ".");
            //var requestUrl = $@"api/category/pmp2g/version/2/geotype/point/lon/{lng}/lat/{lat}/data.json";
            //var requestUrl = $@"api/category/pmp2g/version/2/geotype/point/lon/12.96/lat/57.26/data.json";

            string rawJsonString;

            //string lat = location.Latitude.ToString("F");
            //string lng = location.Longitude.ToString("F");

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

            var locationObj = new Location();
            try
            {
               locationObj  = geoWebservice.AddressToCoordinates(location);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            return locationObj;
        }
 

    }


}
