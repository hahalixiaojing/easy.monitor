using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Monitor.Application.Models.ServiceStatMinute;
using Easy.Monitor.Application.Models.StatMetaData;
using Easy.Monitor.Application.Utility;
using Easy.Monitor.Model.StatMetaData;

namespace Easy.Monitor.Application.Application.StatMetaData
{
    public class StatMetaDataApplication : BaseApplication
    {
        public void Add(StatMetaDataModel[] models)
        {
            var list = models.Select(m => new Model.StatMetaData.StatMetaData()
            {
                ApiPath = m.ApiPath,
                ApiUrl = m.ApiUrl,
                AverageResponseTime = m.AverageResponseTime,
                BaseApiUrl = m.BaseApiUrl,
                ResponseFrequency = m.ResponseFrequency,
                Ip = m.Ip,
                MaxResponseTime = m.MaxResponseTime,
                MinResponseTime = m.MinResponseTime,
                TotalResponseTime = (int)m.TotalResponseTime,
                ServiceName = m.ServiceName,
                StatTime = DateHelper.ToDateTime(m.StatTime),
                AverageRequestResponseTime = m.AverageRequestResponseTime,
                ErrorResponseFrquency = m.ErrorResponseFrquency,
                RequestFrequency = m.RequestFrequency
            }).ToArray();

            Model.RepositoryRegistry.StatMetaData.Add(list);
        }
        /// <summary>
        /// 查询接口统计数据
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="api"></param>
        /// <returns></returns>
        public IEnumerable<FrequencyData> SelectFrequency(string serviceName,string api)
        {
            int totalRows = 0;
            var curentDateTime = DateTime.Now;
            var metadata = Model.RepositoryRegistry.StatMetaData.SelectBy(new Query()
            {
                ApiPath = api,
                ServiceName = serviceName,
                StatTimeStart = curentDateTime.AddMinutes(-30),
                StatTimeEnd = curentDateTime
            }, out totalRows);
            var filterdata = new MetaDataFillService().Fill(curentDateTime, metadata);
            return filterdata.Select(m => new FrequencyData()
                {
                    StatTime = m.StatTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    ResponseFrequency = m.ResponseFrequency / 60d,
                    RequestFrequency = m.RequestFrequency / 60d,
                    AverageRequestTime = m.AverageRequestResponseTime,
                    AverageResponseTime = m.AverageResponseTime
                });
        }

        public Tuple<IEnumerable<FrequencyData>, int> SelectFrequency2(string serviceName, string api, int pageIndex = 1, int pageSize = 100)
        {
            int totalRows = 0;
            var metadata = Model.RepositoryRegistry.StatMetaData.SelectBy(new Query()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                ApiPath = api,
                ServiceName = serviceName
            }, out totalRows);

            var data = metadata.Select(m => new FrequencyData()
            {
                StatTime = m.StatTime.ToString("yyyy-MM-dd HH:mm:00"),
                ResponseFrequency = m.ResponseFrequency,
                RequestFrequency = m.RequestFrequency,
                AverageRequestTime = m.AverageRequestResponseTime,
                AverageResponseTime = m.AverageResponseTime
            });

            return new Tuple<IEnumerable<FrequencyData>, int>(data, totalRows);
        }

        /// <summary>
        /// 获取数据总个数
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="api"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public int GetStatMetaDataCount(string serviceName,string api)
        {
            var curentDateTime = DateTime.Now;
            var result = Model.RepositoryRegistry.StatMetaData.GetStatMetaDataCount(new Query()
            {
                ApiPath = api,
                ServiceName = serviceName,
                StatTimeStart = curentDateTime.AddMinutes(-30),
                StatTimeEnd = curentDateTime
            });
            return result;
        }


    }
}
