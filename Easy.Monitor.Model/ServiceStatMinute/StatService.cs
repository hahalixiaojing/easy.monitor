using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Public;

namespace Easy.Monitor.Model.ServiceStatMinute
{
    public class StatService
    {
        public void Stat(string[] serviceNames)
        {
            foreach (var serviceName in serviceNames)
            {
                Task.Factory.StartNew(() =>
                {
                    var metaDataList = this.SelectMetaData(serviceName);
                    var groupDataList = metaDataList.GroupBy(m => m.StatTime);
                    var statDataList = this.StatData(serviceName, groupDataList);
                    RepositoryRegistry.ServiceStatMinute.Add(statDataList.ToArray());
                });
            }
        }

        private IEnumerable<ServiceStatMinute> StatData(string serviceName, IEnumerable<IGrouping<DateTime, StatMetaData.StatMetaData>> groupDataList)
        {
            var list = new List<ServiceStatMinute>();
            foreach (var item in groupDataList)
            {
                var serviceStatMin = new ServiceStatMinute()
                {
                    StatTime = item.Key,
                    Frequency = item.Sum(m => m.Frequency),
                    MaxResponseTime = item.Max(m => m.MaxResponseTime),
                    MinResponseTime = item.Min(m => m.MinResponseTime),
                    TotalResponseTime = item.Sum(m => m.TotalResponseTime),
                    AverageResponseTime = item.Sum(m => m.TotalResponseTime) / item.Sum(m => m.Frequency),
                    ServiceName = serviceName
                };
                list.Add(serviceStatMin);
            }
            return list;
        }

        private IEnumerable<StatMetaData.StatMetaData> SelectMetaData(string serviceName)
        {
            DateTime? lastDateTime = RepositoryRegistry.ServiceStatMinute.FindMaxStatTime(serviceName);
            var dataList = RepositoryRegistry.StatMetaData.SelectBy(new StatMetaData.Query()
            {
                ServiceName = serviceName,
                StatTimeStart = lastDateTime ?? DateTime.Now.AddMinutes(-10)
            });

            return dataList;
        }
    }
}
