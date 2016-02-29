using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Monitor.Utility
{
    public class OauthLoginFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string userdata = filterContext.ActionParameters["userData"].ToString();


            if (string.IsNullOrWhiteSpace(userdata) || userdata.Split('|').Length != 3)
            {
                filterContext.Result = new RedirectResult(Easy.Public.MvcSecurity.AuthenticateHelper.LoginUrl);
                return;
            }

            double spanTime = Math.Abs((DateTime.Now - DateTime.FromBinary(long.Parse(userdata.Split('|')[2]))).TotalMinutes);
            if (spanTime >= 2)
            {
                filterContext.Result = new RedirectResult(Easy.Public.MvcSecurity.AuthenticateHelper.LoginUrl);
                return;
            }
        }
    }
}