using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Monitor.Application.Models.ServiceStatMinute;
using Easy.Monitor.Model.ServiceHostStatMinute;

namespace Easy.Monitor.Application.Application.ServiceHostStatMinute
{
    public class ServiceHostStatMinuteApplication : BaseApplication
    {
        public void StartStat()
        {
            var serviceNames = Model.RepositoryRegistry.Directory.Select().Select(m => m.Name).ToArray();
            new Model.ServiceHostStatMinute.StatService().Stat(serviceNames);
        }
        public IEnumerable<FrequencyData> SelectFrequency(string serviceName,string host)
        {
            var curentDateTime = DateTime.Now;

            var list =  Model.RepositoryRegistry.ServiceHostStatMinute.SelectBy(new Model.ServiceHostStatMinute.Query()
            {
                ServiceName = serviceName,
                Host = host,
                StatTimeStart = curentDateTime.AddMinutes(-30),
                StatTimeEnd = curentDateTime
            });

            return new StatDataFillService().Fill(curentDateTime, list).Select(m => new FrequencyData()
            {
                StatTime = m.StatTime.ToString("yyyy-MM-dd HH:mm:ss"),
                AverageRequestTime = m.AverageResponseTime,
                AverageResponseTime = m.AverageResponseTime,
                RequestFrequency = m.RequestFrequency / 60d,
                ResponseFrequency = m.ResponseFrequency / 60d
            });
        }
    }
}
