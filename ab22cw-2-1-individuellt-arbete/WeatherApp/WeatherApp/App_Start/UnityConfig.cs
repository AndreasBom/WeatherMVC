using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using WeatherApp.Domain.Repositories;
using WeatherApp.Domain.WebServices;

namespace WeatherApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IWeatherRepository, WeatherRepository>();
            container.RegisterType<IWeatherWebService, WeatherWebService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}