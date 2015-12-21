using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.WebServices
{
    public interface IWeatherWebService
    {
        IEnumerable<Forcast> GetForcast(GeoLocation geoLocation);

        GeoLocation LookUpGeoLocation(string location);
    }
}
