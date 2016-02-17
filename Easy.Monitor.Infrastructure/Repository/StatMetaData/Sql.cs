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
                                    frequency Frequency, 
                                    max_response_time MaxResponseTime, 
                                    mini_response_time MinResponseTime, 
                                    average_response_time AverageResponseTime, 
                                    stat_time StatTime
                        FROM monitor_metadata";
            return sql;
        }

        private static string WhereSql(Model.StatMetaData.Query query)
        {
            SQLBuilder builder = new SQLBuilder();
            builder.AppendWhere();
            builder.Append(query.StatTimeStart != null,"and", "stat_time>=@StatTimeStart");
            builder.Append(query.StatTimeEnd != null, "and", "stat_time<=@StatTimeEnd");

            return builder.Sql();
        }

        public static string SelectByQuery(Model.StatMetaData.Query query)
        {
            return string.Join(" ", BaseSelectSql(), WhereSql(query));
        }

        public static Tuple<string,dynamic[]> Add(Model.StatMetaData.StatMetaData[] data)
        {
            const string sql = @"INSERT INTO monitor_metadata
    (servcie_name, ip, api_url, api_url_hashcode, base_api_url, base_api_url_hashcode, api_path, frequency, max_response_time, mini_response_time, average_response_time, stat_time)

    VALUES(@ServiceName, @Ip, @ApiUrl, @ApiUrlHashcode, @BaseApiUrl, @BaseApiUrlHashcode, @ApiPath, @Frequency, @MaxResponseTime,
@MinResponseTime, @AverageResponseTime, @StatTime)";


           var result = data.Select(m => new
            {
                ServiceName = m.ServiceName,
                Ip = m.Ip,
                ApiUrl = m.ApiUrl,
                ApiUrlHashcode = m.ApiUrl.ToUpper().GetHashCode(),
                BaseApiUrl = m.BaseApiUrl,
                BaseApiUrlHashcode = m.BaseApiUrl.ToUpper().GetHashCode(),
                ApiPath = m.ApiPath,
                Frequency = m.Frequency,
                MaxResponseTime = m.MaxResponseTime,
                MinResponseTime = m.MinResponseTime,
                AverageResponseTime = m.AverageResponseTime,
               StatTime =m.StatTime
               
            });

            return new Tuple<string, dynamic[]>(sql, result.ToArray<dynamic>());

        }

       

        public static string RemoveAll()
        {
            return "delete from monitor_metadata";
        }
    }
}
