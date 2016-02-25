using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Monitor.Application.Models.ServiceStatMinute;
using Easy.Monitor.Model.ServiceStatMinute;

namespace Easy.Monitor.Application.Application.ServiceStatMinute
{
    public class ServiceStatMinuteApplication : BaseApplication
    {
        public void StartStat()
        {
            var serviceNames = Model.RepositoryRegistry.Directory.Select().Select(m => m.Name).ToArray();
            new Model.ServiceStatMinute.StatService().Stat(serviceNames);
        }

        public IEnumerable<FrequencyData> SelectFrequency(string serviceName)
        {
            var curentDateTime = DateTime.Now;

            var list = Model.RepositoryRegistry.ServiceStatMinute.SelectBy(new Model.ServiceStatMinute.Query()
            {
                ServiceName = serviceName,
                StatTimeStart = curentDateTime.AddMinutes(-30),
                StatTimeEnd = curentDateTime
            });

            list = new StatDataFillService().Fill(curentDateTime, list);
            return list.Select(m => new FrequencyData()
            {
                StatTime = m.StatTime.ToString("yyyy-MM-dd HH:mm:ss"),
                Frequency = m.ResponseFrequency,
                AverageResponseTime = m.AverageResponseTime
            });
        }
    }
}
