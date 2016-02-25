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
                    (service_name, response_frequency, max_response_time, min_response_time, average_response_time, stat_time,total_response_time,error_response_frquency,
                                 request_frequency,average_request_response_time)
                    VALUES(@ServiceName, @ResponseFrequency, @MaxResponseTime, @MinResponseTime, @AverageResponseTime, @StatTime,@TotalResponseTime,@ErrorResponseFrquency,@RequestFrequency,@AverageRequestResponseTime)";
        }

        private static string BaseSelectSql()
        {
            const string sql = @"SELECT 
                    service_name ServiceName, 
                    response_frequency ResponseFrequency, 
                    max_response_time MaxResponseTime, 
                    min_response_time MinResponseTime, 
                    average_response_time AverageResponseTime, 
                    stat_time StatTime,
                    total_response_time TotalResponseTime,
                    error_response_frquency ErrorResponseFrquency,
                    request_frequency RequestFrequency,
                    average_request_response_time AverageRequestResponseTime
                    FROM monitor_service_min";

            return sql;
        }

        private static string WhereSql(Model.ServiceStatMinute.Query query)
        {
            SQLBuilder builder = new SQLBuilder();
            builder.AppendWhere();
            builder.Append(query.StatTimeStart != null, "and", "stat_time>@StatTimeStart");
            builder.Append(query.StatTimeEnd != null, "and", "stat_time<=@StatTimeEnd");
            builder.Append(!string.IsNullOrWhiteSpace(query.ServiceName), "and", "service_name=@ServiceName");


            return builder.Sql();
        }

        public static string FindMaxStatTime(string serviceName)
        {
            return "select max(stat_time) from monitor_service_min where service_name='" + serviceName + "'";
        }

        public static string SelectBy(Model.ServiceStatMinute.Query query)
        {
            return string.Join(" ", BaseSelectSql(), WhereSql(query), "ORDER BY stat_time ASC");
        }

        public static string RemoveAll()
        {
            return "delete from monitor_service_min";
        }
    }
}
