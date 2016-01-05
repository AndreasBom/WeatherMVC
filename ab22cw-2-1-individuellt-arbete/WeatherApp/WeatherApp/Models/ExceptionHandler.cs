using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WeatherApp.Models
{
    public class ExceptionHandler : FilterAttribute, IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new JsonResult
            {
                Data = new { success = false, error = filterContext.Exception.ToString() },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
