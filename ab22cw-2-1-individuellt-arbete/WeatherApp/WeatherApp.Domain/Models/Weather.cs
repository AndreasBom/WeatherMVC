using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WeatherApp.Models;

namespace WeatherApp.Domain.Models
{
    [Table("Weather")]
    public class Weather
    {
        [Key]
        public int WeatherId { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public DateTime ValidTime { get; set; } //validTime
        public float Temperature { get; set; } //t
        public int ThunderProbability { get; set; } //tstm
        public int CloudFactor { get; set; } //tcc_mean
        public Preciptation Preciptation { get; set; } //pcat

        //Will keep track of which location this weatherforcast belongs to
        public virtual Location Location { get; set; }


        public Weather()
        {
            // Empty
        }

        public Weather(JToken weatherItem, Location location)
        {
            LocationId = location.LocationId;
            ValidTime = DateTime.ParseExact(weatherItem["validTime"].ToString(),
                "yyyy-MM-dd HH:mm:ss", null);
            Temperature = ExtractInfo(weatherItem, "t");
            CloudFactor = ExtractInfo(weatherItem, "tcc_mean");
            ThunderProbability = ExtractInfo(weatherItem, "tstm");
            Preciptation = ExtractInfo(weatherItem, "pcat");
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
