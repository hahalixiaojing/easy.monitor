using System.Web.Mvc;
using Easy.Monitor.Utility;

namespace Easy.Monitor.Controllers
{
    [WebAuthorize]
    public class ServiceApiMiniChartController : BaseController
    {
        public ActionResult Index(string serviceName, string api)
        {
            ViewBag.ServiceName = serviceName;
            ViewBag.Api = api;
            return View();
        }

        public JsonResult SelectFrequency(string serviceName, string api)
        {
            var result = Application.ApplicationRegistry.StatMetaData.SelectFrequency(serviceName, api);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}