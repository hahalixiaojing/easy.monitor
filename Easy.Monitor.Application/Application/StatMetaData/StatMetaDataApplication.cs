using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Monitor.Application.Models.StatMetaData;
using Easy.Monitor.Application.Utility;

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
                Frequency = m.Frequency,
                Ip = m.Ip,
                MaxResponseTime = m.MaxResponseTime,
                MinResponseTime = m.MinResponseTime,
                TotalResponseTime = (int)m.TotalResponseTime,
                ServiceName = m.ServiceName,
                StatTime = DateHelper.ToDateTime(m.StatTime)
            }).ToArray();

            Model.RepositoryRegistry.StatMetaData.Add(list);
        }
    }
}
