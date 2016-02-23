using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Model.ServiceHostStatMinute
{
    public class Query
    {
        public String ServiceName { get; set; }
        public String Host { get; set; }
        public DateTime? StatTimeStart { get; set; }
        public DateTime? StatTimeEnd { get; set; }
    }
}
