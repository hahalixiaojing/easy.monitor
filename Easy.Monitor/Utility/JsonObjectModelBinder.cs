using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Monitor.Utility 
{
    /// <summary>
    /// JSON转换器
    /// </summary>
    /// <typeparam name="T">要转换的类型</typeparam>
    public class JsonObjectModelBinder<T> : IModelBinder where T : class
    {
        /// <summary>
        /// JSON转换器
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var response = controllerContext.HttpContext.Response;

            var jsondata = request[bindingContext.ModelName];

            if (string.IsNullOrEmpty(jsondata))
            {
                return null;
            }
          
            return JsonConvert.DeserializeObject<T>(jsondata);
        }
    }
}