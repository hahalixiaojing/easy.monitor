using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy.Monitor.Utility
{
    public static class UserLoginHelper
    {
        public static Tuple<int,string> GetUserData(string userdata)
        {
            string[] data = userdata.Split('|');

            int userid = Int32.Parse(data[0]);
            string username = data[1];

            return new Tuple<int, string>(userid, username);
        }
    }
}