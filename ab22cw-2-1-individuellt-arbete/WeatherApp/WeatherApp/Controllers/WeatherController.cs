using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WeatherApp.Domain.Models;
using WeatherApp.Domain.Repositories;
using WeatherApp.Domain.Services;
using WeatherApp.Domain.WebServices;
using WeatherApp.Models;
using WeatherApp.Views.Weather;
using WebGrease.Css.Ast.Selectors;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private static readonly string SessionLocation = "location";
        // GET: Weather
        public ActionResult Index()
        {
            var reader = new DefaultConfig(HttpContext.Server.MapPath("~/App_Data/XML/config.xml"));
            var location = reader.GetDefaultLocation();
            var model = new WeatherIndexViewModel
            {
                LocationInput = location
            };

            model.LocationObject = model.WeatherService.GetLocation(model.LocationInput);
            Session[SessionLocation] = model.LocationInput;
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index(FormCollection collection)
        {
            var model = new WeatherIndexViewModel();
            
            if (TryUpdateModel(model, new[] {"LocationInput"}, collection))
            {
                try
                {
                    model.LocationObject = model.WeatherService.GetLocation(model.LocationInput);
                    Session[SessionLocation] = model.LocationInput;
                }
                catch (GeoLocationNotFoundException)
                {
                    ModelState.AddModelError("LocationNotFound", "Platsen hittades inte");
                    model.LocationInput = (string)Session[SessionLocation];
                    model.LocationObject = model.WeatherService.GetLocation(model.LocationInput);
                    return View(model);
                }
                
            }
            model.LocationInput = (string)Session[SessionLocation];

            return View(model);
        }

        public ActionResult GetTempData()
        {
            var model = new WeatherIndexViewModel
            {
                LocationInput = (string)Session[SessionLocation]
            };
            model.LocationObject = model.WeatherService.GetLocation(model.LocationInput);

            var temp = from t in model.Weather
                       select new { day = model.DayOfWeek(t.ValidTime), temp = t.Temperature };

            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        


        //public ActionResult GetAutoCompleteData()
        //{
        //    var service = new WeatherService();
        //    var model = service.GetAllLocations();

        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    filterContext.ExceptionHandled = true;
        //    filterContext.Result = RedirectToAction("Index", "Error");
        //}

    }

}