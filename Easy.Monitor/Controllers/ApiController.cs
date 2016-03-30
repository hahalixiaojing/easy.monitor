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
            var serviceModel = ApplicationRegistry.Directory.FindById(serviceId);

            var apiList = ApplicationRegistry.Api.Select(serviceId);
            ViewBag.NodeCount = providerCount;
            ViewBag.ServiceName = serviceModel.Name;
            return View(apiList);
        }
    }
}