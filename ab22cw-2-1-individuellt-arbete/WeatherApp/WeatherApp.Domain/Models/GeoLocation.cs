using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherApp.Domain.Models
{

    public partial class GeoLocation
    {
        //public int GeoLocationId { get; set; }
        //public float Latitude { get; set; }
        //public float Longitude { get; set; }
        //public string Location { get; set; }

        public GeoLocation(JToken geoLocationToken)
            : this()
        {
            Latitude = (float) Math.Round((float) geoLocationToken["results"][0]["geometry"]["location"]["lat"], 6);
            Longitude = (float)Math.Round((float)geoLocationToken["results"][0]["geometry"]["location"]["lng"], 6);
            Location = (string)geoLocationToken["results"][0]["address_components"][0]["long_name"];
        }
    }
}
