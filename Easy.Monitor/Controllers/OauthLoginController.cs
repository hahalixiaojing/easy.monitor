using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Monitor.Utility;
using Easy.Public.MvcSecurity;

namespace Easy.Monitor.Controllers
{
    public class OauthLoginController : Controller
    {
        [OauthLoginFilter]
        public ActionResult Index([ModelBinder(typeof(UserDataModelBinder))]string userData)
        {
            var tuple = UserLoginHelper.GetUserData(userData);
            AuthenticateHelper.SetTicket(tuple.Item1.ToString(), null, 0, tuple.Item2);

            return Redirect("/Home/Index");

        }
    }
}