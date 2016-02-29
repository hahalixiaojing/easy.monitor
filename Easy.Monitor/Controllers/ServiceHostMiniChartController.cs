using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Monitor.Controllers
{
    public class ServiceHostMiniChartController : BaseController
    {
        public ActionResult Index(string serviceName,string host)
        {
            ViewBag.ServiceName = serviceName;
            ViewBag.Host = host;
            return View();
        }

        public ActionResult Select(string serviceName,string host)
        {
            var list = Application.ApplicationRegistry.ServiceHostStatMinute.SelectFrequency(serviceName, host);
            return Json(list);
        }
    }
}