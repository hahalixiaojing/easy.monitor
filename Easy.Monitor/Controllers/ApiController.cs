using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Monitor.Application;
using Easy.Monitor.Utility;

namespace Easy.Monitor.Controllers
{
    [WebAuthorize]
    public class ApiController : Controller
    {
        public ActionResult Index(int serviceId,int providerCount)
        {
            var apiList = ApplicationRegistry.Api.Select(serviceId);
            ViewBag.NodeCount = providerCount;
            return View(apiList);
        }
    }
}