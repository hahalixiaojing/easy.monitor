using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Public;

namespace Easy.Monitor.Infrastructure.Repository.ServiceStatMinute
{
    static class Sql
    {
        public static string Add()
        {
            return @"INSERT INTO monitor_service_min
                    (service_name, frequency, max_response_time, min_response_time, average_response_time, stat_time)
                    VALUES(@ServiceName, @Frequency, @MaxResponseTime, @MinResponseTime, @AverageResponseTime, @StatTime)";
        }

        private static string BaseSelectSql()
        {
            const string sql = @"SELECT 
                    service_name ServiceName, 
                    frequency Frequency, 
                    max_response_time MaxResponseTime, 
                    min_response_time MinResponseTime, 
                    average_response_time AverageResponseTime, 
                    stat_time StatTime
                    FROM monitor_service_min";

            return sql;
        }

        private static string WhereSql(Model.ServiceStatMinute.Query query)
        {
            SQLBuilder builder = new SQLBuilder();
            builder.AppendWhere();
            builder.Append(query.StatTimeStart != null, "and", "stat_time>=@StatTimeStart");
            builder.Append(query.StatTimeEnd != null, "and", "stat_time<=@StatTimeEnd");

            return builder.Sql();
        }

        public static string SelectBy(Model.ServiceStatMinute.Query query)
        {
            return string.Join(" ", BaseSelectSql(), WhereSql(query));
        }

        public static string RemoveAll()
        {
            return "delete from monitor_service_min";
        }
    }
}
