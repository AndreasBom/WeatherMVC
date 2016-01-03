using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Services
{
    public interface IWeatherService : IDisposable
    {
        Location GetLocation(string location);
        void UpdateWeather(Location locationObject);
        //ICollection<Weather> GetWeather(Location locationObject);
        
    }
}
