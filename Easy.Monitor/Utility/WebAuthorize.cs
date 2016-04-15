using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Public.MvcSecurity;

namespace Easy.Monitor.Utility
{
    public class WebAuthorize : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {

            //var request = filterContext.HttpContext.Request;
            //AuthenticateUserTicket ticket = AuthenticateHelper.AuthenticateTicket();
            //if (ticket != null && !ticket.Expired)
            //{
            //    if (request.AppRelativeCurrentExecutionFilePath.ToUpper() == AuthenticateHelper.LoginUrl.ToUpper())
            //    {//已经登录则不能再进入登录页面
            //        filterContext.Result = new RedirectResult(AuthenticateHelper.LoginRedirectPage);
            //        return;
            //    }
            //    filterContext.HttpContext.User = new AuthenticateUser(ticket);
            //}
            //else
            //{
            //    filterContext.Result = new RedirectResult(AuthenticateHelper.LoginUrl);
            //}
        }
    }
}