using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Domain.Models
{
    public class WeatherForcastDbContext : DbContext
    {
        public WeatherForcastDbContext()
            : base("name=WeatherForcastDb")
        {
        }
        public  DbSet<Location> Locations { get; set; }
        public  DbSet<Weather> Weather { get; set; }
    }
}
