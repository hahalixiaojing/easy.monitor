using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Easy.Monitor.Contoller
{
    public class BaseController:Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        /// <param name="contentEncoding"></param>
        /// <returns></returns>
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return new CustomerJsonResult() { Data = data, ContentEncoding = contentEncoding, ContentType = contentType };
        }


        /// <summary>
        /// 创建一个将指定对象序列化为 JavaScript 对象表示法 (JSON) 的 <see cref="T:System.Web.Mvc.JsonResult" /> 对象。
        /// </summary>
        /// <param name="data">要序列化的 JavaScript 对象图。</param>
        /// <returns>
        /// 将指定对象序列化为 JSON 格式的 JSON 结果对象。在执行此方法所准备的结果对象时，ASP.NET MVC 框架会将该对象写入响应。
        /// </returns>
        protected new JsonResult Json(object data)
        {
            return new CustomerJsonResult() { Data = data };
        }

        protected new JsonResult Json(object data, JsonRequestBehavior behavior)
        {
            return new CustomerJsonResult() { Data = data, JsonRequestBehavior = behavior };
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class CustomerJsonResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");


            var response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;
            var serializedObject = JsonConvert.SerializeObject(Data, new JsonSerializerSettings() { DateFormatString = "yyyy-MM-dd HH:mm:ss" });
            response.Write(serializedObject);
        }
    }
}