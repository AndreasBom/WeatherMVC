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
        GeoLocation GetLocation(string location);
        void RefreshForcasts(GeoLocation location);
    }
}
