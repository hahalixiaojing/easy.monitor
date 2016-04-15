using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Public;

namespace Easy.Monitor.Infrastructure.Repository.StatMetaData
{
    class Sql
    {
        private static string BaseSelectSql()
        {
            const string sql = @"SELECT 
                                    servcie_name ServiceName, 
                                    ip Ip, 
                                    api_url ApiUrl, 
                                    base_api_url BaseApiUrl, 
                                    api_path ApiPath, 
                                    response_frequency ResponseFrequency, 
                                    max_response_time MaxResponseTime, 
                                    mini_response_time MinResponseTime, 
                                    average_response_time AverageResponseTime,
                                    total_response_time TotalResponseTime, 
                                    stat_time StatTime,
                                    error_response_frquency ErrorResponseFrquency,
                                    request_frequency RequestFrequency,
                                    average_request_response_time AverageRequestResponseTime
                        FROM monitor_metadata";
            return sql;
        }

        private static string WhereSql(Model.StatMetaData.Query query)
        {
            SQLBuilder builder = new SQLBuilder();
            builder.AppendWhere();
            builder.Append(query.StatTimeStart != null,"and", "stat_time>@StatTimeStart");
            builder.Append(query.StatTimeEnd != null, "and", "stat_time<=@StatTimeEnd");
            builder.Append(!string.IsNullOrWhiteSpace(query.ServiceName), "and", "servcie_name=@ServiceName");
            builder.Append(!string.IsNullOrWhiteSpace(query.ApiPath), "and", "api_path=@ApiPath");
            return builder.Sql();
        }

        public static string SelectByQuery(Model.StatMetaData.Query query)
        {
            return string.Join(" ", BaseSelectSql(), WhereSql(query), "ORDER BY stat_time ASC", "LIMIT @Limit OFFSET @Offset;");
        }

        public static Tuple<string, dynamic> SelectMetaDataCount(Model.StatMetaData.Query query)
        {
            string sql = string.Format("SELECT COUNT(*) FROM  monitor_metadata {0}", WhereSql(query));

            return new Tuple<string, dynamic>(sql, new
            {
                StatTimeStart = query.StatTimeStart, 
                StatTimeEnd = query.StatTimeEnd,
                ServiceName = query.ServiceName,
                ApiPath = query.ApiPath
            });
        }

        public static Tuple<string,dynamic[]> Add(Model.StatMetaData.StatMetaData[] data)
        {
            const string sql = @"INSERT INTO monitor_metadata
                                (servcie_name, ip, api_url, api_url_hashcode, base_api_url, base_api_url_hashcode, 
                                 api_path, response_frequency, max_response_time, mini_response_time,
                                 average_response_time, stat_time,total_response_time,error_response_frquency,
                                 request_frequency,average_request_response_time)
    VALUES(@ServiceName, @Ip, @ApiUrl, @ApiUrlHashcode, @BaseApiUrl, @BaseApiUrlHashcode, @ApiPath, @ResponseFrequency, @MaxResponseTime,
@MinResponseTime, @AverageResponseTime, @StatTime,@TotalResponseTime,@ErrorResponseFrquency,@RequestFrequency,@AverageRequestResponseTime)";


            var result = data.Select(m => new
            {
                ServiceName = m.ServiceName,
                Ip = m.Ip,
                ApiUrl = m.ApiUrl,
                ApiUrlHashcode = m.ApiUrl.ToUpper().GetHashCode(),
                BaseApiUrl = m.BaseApiUrl,
                BaseApiUrlHashcode = m.BaseApiUrl.ToUpper().GetHashCode(),
                ApiPath = m.ApiPath,
                ResponseFrequency = m.ResponseFrequency,
                MaxResponseTime = m.MaxResponseTime,
                MinResponseTime = m.MinResponseTime,
                AverageResponseTime = m.AverageResponseTime,
                StatTime = m.StatTime,
                TotalResponseTime = m.TotalResponseTime,
                AverageRequestResponseTime = m.AverageRequestResponseTime,
                ErrorResponseFrquency = m.ErrorResponseFrquency,
                RequestFrequency = m.RequestFrequency
            });

            return new Tuple<string, dynamic[]>(sql, result.ToArray<dynamic>());

        }

       

        public static string RemoveAll()
        {
            return "delete from monitor_metadata";
        }
    }
}
