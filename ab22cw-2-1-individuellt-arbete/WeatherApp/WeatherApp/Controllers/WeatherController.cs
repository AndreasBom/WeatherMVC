using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WeatherApp.Domain.WebServices;
using WeatherApp.Views.Weather;


namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private static readonly string SessionLocation = "location";
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public WeatherController()
        {
            //Empty!
        }

        public WeatherController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: 
        public ActionResult Index()
        {

            //Kalmar will be shown if user is not logged in
            var location = "Kalmar";

            //If user is logged in and have saved a default location
            if (User.Identity.Name != String.Empty)
            {
                var user = UserManager.FindById(User.Identity.GetUserId());
                if (user != null)
                {
                    location = user.DefaultLocation;
                }
            }

            var model = new WeatherIndexViewModel
            {
                LocationInput = location
            };

            model.LocationObject = model.WeatherService.GetLocation(model.LocationInput);
            Session[SessionLocation] = model.LocationInput;
            return View(model);
        }

        /// <summary>
        /// POST: Search for location
        /// </summary>
        /// <param name="Formcollection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index(FormCollection collection)
        {
            var model = new WeatherIndexViewModel();

            if (TryUpdateModel(model, new[] { "LocationInput" }, collection))
            {
                try
                {
                    model.LocationObject = model.WeatherService.GetLocation(model.LocationInput);
                    Session[SessionLocation] = model.LocationInput;
                }
                catch (GeoLocationNotFoundException)
                {
                    //Shows an error if location is not found
                    ModelState.AddModelError("LocationNotFound", "Platsen hittades inte");
                }

            }
            model.LocationInput = (string)Session[SessionLocation];
            model.LocationObject = model.WeatherService.GetLocation(model.LocationInput);

            model.LocationInput = (string)Session[SessionLocation];

            return View(model);
        }

        /// <summary>
        /// Returns an Json, and is used by graph.js
        /// </summary>
        /// <returns></returns>
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

        //Catches all unhandled exceptions and redirects to Errorhandler
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            ModelState.AddModelError(string.Empty, "Något gick fel");

            filterContext.Result = RedirectToAction("Index");
        }


    }

}