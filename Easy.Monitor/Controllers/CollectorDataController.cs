using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Easy.Monitor.Application.Models.StatMetaData;
using Easy.Monitor.Controllers;
using Easy.Monitor.Utility;

namespace Easy.Monitor.Contoller
{
    public class CollectorDataController : BaseController
    {
        /// <summary>
        /// 收集统计数据接口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult Collector([ModelBinder(typeof(JsonObjectModelBinder<StatMetaDataModel[]>))]StatMetaDataModel[] data)
        {
            Application.ApplicationRegistry.StatMetaData.Add(data);

            return Content("");
        }
    }
}