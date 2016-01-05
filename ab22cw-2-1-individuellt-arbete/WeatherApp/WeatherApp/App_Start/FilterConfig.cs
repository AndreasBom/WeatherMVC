using System.Web;
using System.Web.Mvc;
using WeatherApp.Models;

namespace WeatherApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new ExceptionHandler());
        }
    }
}
