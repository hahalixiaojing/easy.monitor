using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Public;

namespace Easy.Monitor.Infrastructure.Repository.ServiceHostStatMinute
{
    static class Sql
    {
        public static string Add()
        {
            return @"INSERT INTO monitor_service_host_min
                    (service_name, frequency, max_response_time, mini_response_time, average_response_time, stat_time,host,total_response_time)
                    VALUES(@ServiceName, @Frequency, @MaxResponseTime, @MinResponseTime, @AverageResponseTime, @StatTime,@Host,@TotalResponseTime)";
        }

        private static string BaseSelectSql()
        {
            const string sql = @"SELECT 
                    service_name ServiceName, 
                    frequency Frequency, 
                    max_response_time MaxResponseTime, 
                    mini_response_time MinResponseTime, 
                    average_response_time AverageResponseTime, 
                    stat_time StatTime,
                    host Host,
                    total_response_time TotalResponseTime
                    FROM monitor_service_host_min";

            return sql;
        }
        private static string WhereSql(Model.ServiceHostStatMinute.Query query)
        {
            SQLBuilder builder = new SQLBuilder();
            builder.AppendWhere();
            builder.Append(query.StatTimeStart != null, "and", "stat_time>@StatTimeStart");
            builder.Append(query.StatTimeEnd != null, "and", "stat_time<=@StatTimeEnd");
            builder.Append(!string.IsNullOrWhiteSpace(query.Host), "and", "host=@Host");
            builder.Append(!string.IsNullOrWhiteSpace(query.ServiceName), "and", "service_name=@ServiceName");

            return builder.Sql();
        }

        public static string FindMaxStatTime(string serviceName)
        {
            return "select max(stat_time) from monitor_service_host_min where service_name='" + serviceName + "'";
        }
        public static string SelectBy(Model.ServiceHostStatMinute.Query query)
        {
            return string.Join(" ", BaseSelectSql(), WhereSql(query));
        }

        public static string RemoveAll()
        {
            return "delete from monitor_service_host_min";
        }
    }
}
