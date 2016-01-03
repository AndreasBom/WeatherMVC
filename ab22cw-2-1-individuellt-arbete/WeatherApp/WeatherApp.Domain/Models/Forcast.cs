using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace WeatherApp.Domain.Models
{
    public enum Preciptation
    {
        None,
        Snow,
        Rain,
        Drizzle,
        FreezingRain,
        FreezingDrizzle
    }

    public partial class Forcast
    {
        //Properties can be found in partial class in DataModels
        
        //public DateTime ValidTime { get; set; } //validTime
        //public float Temperature { get; set; } //t
        //public int ThunderProbability { get; set; } //tstm
        //public int CloudFactor { get; set; } //tcc_mean
        //public Preciptation Preciptation { get; set; } //pcat

        public Forcast()
        {
            // Empty
        }

        public Forcast(JToken weatherItem, GeoLocation geoLocation)
        {
            ValidTime = DateTime.ParseExact(weatherItem["validTime"].ToString(),
                "yyyy-MM-dd HH:mm:ss", null);
            Temperature = ExtractInfo(weatherItem, "t");
            CloudFactor = ExtractInfo(weatherItem, "tcc_mean");
            ThunderProbability = ExtractInfo(weatherItem, "tstm");
            Preciptation = ExtractInfo(weatherItem, "pcat");
            GeoLocationId = geoLocation.GeoLocationId;
            //GeoLocation =  geoLocation;
        }

        private dynamic ExtractInfo(JToken weatherItem, string jsonPath)
        {
            var extractedData = (from w in weatherItem["parameters"]
                  where w.Value<string>("name") == jsonPath
                  select w["values"][0]).FirstOrDefault();

            return extractedData;
        }
    }

}
