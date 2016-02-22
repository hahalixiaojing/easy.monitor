using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Application.Utility
{
    public static class DateHelper
    {
        public static DateTime ToDateTime(string data)
        {
            int year = int.Parse(data.Substring(0, 4));
            int month = int.Parse(data.Substring(4, 2));
            int day = int.Parse(data.Substring(6, 2));
            int hour = int.Parse(data.Substring(8, 2));
            int minute = int.Parse(data.Substring(10, 2));

            return new DateTime(year, month, day, hour, minute, 0);
        }
    }
}
