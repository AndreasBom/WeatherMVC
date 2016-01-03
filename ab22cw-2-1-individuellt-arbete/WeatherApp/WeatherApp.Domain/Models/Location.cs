using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherApp.Domain.Models
{
    [Table("Location")]
    public class Location
    {
        public int LocationId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string LocationText { get; set; }

        public virtual ICollection<Weather> WeatherForcasts { get; set; }


        public Location(JToken location)
        {
            Latitude = (float)Math.Round((float)location["results"][0]["geometry"]["location"]["lat"], 6);
            Longitude = (float)Math.Round((float)location["results"][0]["geometry"]["location"]["lng"], 6);
            LocationText = (string)location["results"][0]["address_components"][0]["long_name"];
        }

        public Location()
        {
            //Empty
        }
    }
}
