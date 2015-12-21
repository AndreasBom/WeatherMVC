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
            Temperature = (float) weatherItem["t"];
            CloudFactor = (int) weatherItem["tcc_mean"];
            ThunderProbability = (int) weatherItem["tstm"];
            Preciptation = (string)Enum.ToObject(typeof(Preciptation), (int)weatherItem["pcat"]).ToString();
            GeoLocationId = geoLocation.GeoLocationId;
            GeoLocation = geoLocation;
        }
    }

}
