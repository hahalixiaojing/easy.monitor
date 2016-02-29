using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Monitor.Utility;

namespace Easy.Monitor.Controllers
{
    [WebAuthorize]
    public class NodeController:BaseController
    {
        public ActionResult Index(int serviceId,string name)
        {
            ViewBag.ServiceName = name;
            var list = Application.ApplicationRegistry.Node.Select(serviceId);
            return View(list);
        }
    }
}