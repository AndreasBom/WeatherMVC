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
    public enum Preciptation
    {
        None,
        Snow,
        Rain,
        Drizzle,
        FreezingRain,
        FreezingDrizzle
    }

    [Table("Weather", Schema = "weatherApp")]
    public class Weather
    {
        [Key]
        public int WeatherId { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public DateTime NextUpdate { get; set; }
        public DateTime ValidTime { get; set; } //validTime
        public float Temperature { get; set; } //t
        public int ThunderProbability { get; set; } //tstm
        public int CloudFactor { get; set; } //tcc_mean
        public Preciptation Preciptation { get; set; } //pcat
        public float AmountPreciptation { get; set; }//pmean
        public int Symbol => InterpretWeatherDataAndAssignSymbol();

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
            AmountPreciptation = ExtractInfo(weatherItem, "pmean");
        }

        private dynamic ExtractInfo(JToken weatherItem, string jsonPath)
        {
            var extractedData = (from w in weatherItem["parameters"]
                                 where w.Value<string>("name") == jsonPath
                                 select w["values"][0]).FirstOrDefault();

            return extractedData;
        }

        private int InterpretWeatherDataAndAssignSymbol()
        {
            var symbol = 0;
            if (CloudFactor < 3 && AmountPreciptation < 0.5 )
            {
                symbol = 1;
            }
            if (CloudFactor >= 3 && CloudFactor < 6)
            {
                if (AmountPreciptation < 2)
                {
                    symbol = 3;
                }
                else
                {
                    symbol = 4;
                }
            }
            if (CloudFactor >= 6)
            {
                if (AmountPreciptation < 2)
                {
                    symbol = 2;
                }
                else
                {
                    if (Temperature < 1)
                    {
                        symbol = 8;
                    }
                    else
                    {
                        symbol = 5;
                    }
                    
                }
            }
            if (ThunderProbability > 50)
            {
                symbol = 6;
            }

            return symbol;
        }
    }
}
