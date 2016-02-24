using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Monitor.Contoller
{
    public class ServiceMiniChartController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult SelectFrequency(string serviceName)
        {
            var result = Application.ApplicationRegistry.ServiceStatMinute.SelectFrequency(serviceName);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}