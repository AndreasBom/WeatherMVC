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
        public ActionResult Index(ExceptionContext context)
        {
            var error = new {error = "Ett fel inträffade"};
            return Json(error, JsonRequestBehavior.AllowGet);
        }
    }
}