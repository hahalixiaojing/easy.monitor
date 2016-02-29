using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Public.Security.Cryptography;

namespace Easy.Monitor.Utility
{
    public class UserDataModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string userdata = controllerContext.HttpContext.Request[bindingContext.ModelName];
            if (string.IsNullOrWhiteSpace(userdata))
            {
                return string.Empty;
            }
            userdata = DESHelper.Decrypt(userdata);
            return userdata;
        }
    }
}