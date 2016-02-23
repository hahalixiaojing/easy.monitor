using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Model.ServiceHostStatMinute
{
    public class StatService
    {
        public void Stat(string[] serviceNames)
        {
            foreach (var serviceName in serviceNames)
            {
                Task.Factory.StartNew(() =>
                {
                    List<ServiceHostStatMinute> statList = new List<ServiceHostStatMinute>();
                    var metaDataList = this.SelectMetaData(serviceName);
                    var groupStatTime = metaDataList.GroupBy(m => m.StatTime);
                    foreach (var item in groupStatTime)
                    {
                        var groupIps = item.GroupBy(m => m.Ip);
                        var list = this.StatData(serviceName, item.Key, groupIps);
                        statList.AddRange(list);
                    }
                    RepositoryRegistry.ServiceHostStatMinute.Add(statList.ToArray());
                });
            }
        }

        private IList<ServiceHostStatMinute> StatData(string serviceName,DateTime statTime,IEnumerable<IGrouping<string,StatMetaData.StatMetaData>> groupIps)
        {
            var statList = new List<ServiceHostStatMinute>();
            foreach (var groupIp in groupIps)
            {
                var stat = new ServiceHostStatMinute()
                {
                    Frequency = groupIp.Sum(m => m.Frequency),
                    Host = groupIp.Key,
                    MaxResponseTime = groupIp.Max(m => m.MaxResponseTime),
                    MinResponseTime = groupIp.Min(m => m.MinResponseTime),
                    ServiceName = serviceName,
                    StatTime = statTime,
                    TotalResponseTime = groupIp.Sum(m => m.TotalResponseTime),
                    AverageResponseTime = groupIp.Sum(m => m.TotalResponseTime) / groupIp.Sum(m => m.Frequency)
                };
                statList.Add(stat);
            }
            return statList;
        }


        private IEnumerable<StatMetaData.StatMetaData> SelectMetaData(string serviceName)
        {
            DateTime? lastDateTime = RepositoryRegistry.ServiceHostStatMinute.FindMaxStatTime(serviceName);
            var dataList = RepositoryRegistry.StatMetaData.SelectBy(new StatMetaData.Query()
            {
                ServiceName = serviceName,
                StatTimeStart = lastDateTime ?? DateTime.Now.AddMinutes(-10)
            });

            return dataList;
        }
    }
}
