using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Infrastructure.Repository.Api
{
    static class Sql
    {
        public static string Select(int serviceId)
        {
            return "select id as Id,api_name as Name from register_apis where directory_id=" + serviceId;
        }
    }
}
