using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Monitor.Controllers
{
    public class DirectoryController : BaseController
    {
        public ActionResult Index()
        {
            var list = Application.ApplicationRegistry.Directory.Select();
            return View(list);
        }
    }
}