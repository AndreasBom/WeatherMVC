﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NGeo.GeoNames;
using WeatherApp.Domain.Models;
using static System.Configuration.ConfigurationSettings;

namespace WeatherApp.Domain.WebServices
{
    public class GeoLocationWebService
    {
        private static readonly string BaseUrl = @"https://maps.googleapis.com/maps/api/geocode/json?address=";
        private static string ApiKey;

        //public float Latitude { get; set; }
        //public float Longitude { get; set; }
        //public string Location { get; set; }
        private string Country => "Sweden";

        public GeoLocationWebService()
        {
            ApiKey = AppSettings.Get("geoLocationApiKey");
        }

        
        public Location AddressToCoordinates(string location)
        {
            var webClient = new WebClient();

            string rawJson;

            string requestUrl = $"{location}, {Country},&key={ApiKey}";
            var request = (HttpWebRequest)WebRequest.Create($"{BaseUrl}{requestUrl}");
            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "application/json; charset=utf-8";

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJson = reader.ReadToEnd();
            }

            //Parse to JObject
            var jObj = JObject.Parse(rawJson);
            
            //Thrown an exception if location is not found 
            if (jObj.Value<string>("status") == "ZERO_RESULTS")
            {
                throw new GeoLocationNotFoundException("No location found");
            }

            return new Location(jObj);
        }
    }

    public class GeoLocationNotFoundException : Exception
    {
        public GeoLocationNotFoundException()
        {
        }

        public GeoLocationNotFoundException(string message)
        : base(message)
    {
        }

        public GeoLocationNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
        }
    }
}
