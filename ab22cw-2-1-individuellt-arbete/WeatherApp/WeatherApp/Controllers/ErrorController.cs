using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            var error = new {error = "Somthing went wrong"};
            return Json(error, JsonRequestBehavior.AllowGet);
        }
    }
}