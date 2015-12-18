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

    public class Weather
    {
        
        public float Temperature { get; set; } //t
        public int CloudFactor { get; set; } //tcc_mean
        public int ThunderProbability { get; set; } //tstm
        public Preciptation Preciptation { get; set; } //pcat

        public Weather(JToken weatherItem)
        {
            Temperature = (float) weatherItem["t"];
            CloudFactor = (int) weatherItem["tcc_mean"];
            ThunderProbability = (int) weatherItem["tstm"];
            //Preciptation = (Preciptation)Enum.ToObject(typeof(Preciptation), weatherItem["pcat"]);
        }
    }

}
