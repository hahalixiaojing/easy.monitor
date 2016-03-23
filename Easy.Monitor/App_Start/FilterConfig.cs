using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Monitor.Utility;

namespace Easy.Monitor.App_Start
{
    /// <summary>
    /// MVC过滤器配置
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// 注册过滤器
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorAttribute());
        }
    }
}