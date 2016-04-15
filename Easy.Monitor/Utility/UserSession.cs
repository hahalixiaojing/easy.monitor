using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Easy.Public.MvcSecurity;

namespace Easy.Monitor.Utility
{
    public static class UserSession
    {
        public static string User
        {
            get
            {
                return string.Empty;
                var user = HttpContext.Current.User as AuthenticateUser;
                return user.UserData;
            }
        }

        public static Tuple<int, string> UserInfoDetail
        {
            get
            {
                return new Tuple<int, string>(1, "fsdsdf");
                var user = HttpContext.Current.User as AuthenticateUser;

                int id = int.Parse(user.Identity.Name);
                string username = user.UserData;
                return new Tuple<int, string>(id, username);
            }
        }
    }
}