using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Infrastructure.Repository.Node
{
    static class Sql
    {
        public static string Select(int serviceId)
        {
            return "select directory_name as ServiceName,id as Id,ip as Ip,url as Url from register_node where directory_id=" + serviceId;
        }
    }
}
