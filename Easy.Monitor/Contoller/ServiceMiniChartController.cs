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


        public JsonResult LoadData(string serviceName)
        {
            var result = Application.ApplicationRegistry.ServiceStatMinute.Select(serviceName);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}