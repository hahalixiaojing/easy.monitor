﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Monitor.Controllers
{
    public class ServiceApiMiniTableController : Controller
    {
        // GET: ServiceApiMiniTable
        public ActionResult Index(string serviceName, string api)
        {
            ViewBag.ServiceName = serviceName;
            ViewBag.Api = api;
            ViewBag.DataCount=Application.ApplicationRegistry.StatMetaData.GetStatMetaDataCount(serviceName, api);
            return View();
        }

        [HttpPost]
        public ActionResult SelectMetadataByPage(string serviceName, string api, int pageIndex = 1, int pageSize = 100)
        {
            var list = Application.ApplicationRegistry.StatMetaData.SelectFrequency2(serviceName, api, pageIndex, pageSize);
            return this.PartialView("TableDataTemplate", list);
        }
    }
}