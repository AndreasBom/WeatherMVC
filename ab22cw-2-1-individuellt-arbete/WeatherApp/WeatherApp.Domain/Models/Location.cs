using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;

namespace WeatherApp.Domain.Models
{
    
    [Table("Location", Schema = "weatherApp")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        [StringLength(100)]
        public string PlaceCode { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        [MaxLength(50)]
        public string LocationText { get; set; }

        public virtual ICollection<Weather> WeatherForcasts { get; set; }


        public Location(JToken location)
        {
            PlaceCode = (string) location["results"][0]["place_id"];
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
