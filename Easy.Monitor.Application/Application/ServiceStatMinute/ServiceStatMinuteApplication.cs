using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Monitor.Application.Models.ServiceStatMinute;

namespace Easy.Monitor.Application.Application.ServiceStatMinute
{
    public class ServiceStatMinuteApplication : BaseApplication
    {
        public void StartStat()
        {
            var serviceNames = Model.RepositoryRegistry.Directory.Select().Select(m => m.Name).ToArray();
            new Model.ServiceStatMinute.StatService().Stat(serviceNames);
        }

        public IEnumerable<FrequencyData> Select(string serviceName)
        {
            var list = Model.RepositoryRegistry.ServiceStatMinute.SelectBy(new Model.ServiceStatMinute.Query()
            {
                ServiceName = serviceName,
                StatTimeStart = DateTime.Now.AddMinutes(-30),
                StatTimeEnd = DateTime.Now
            });

            return list.Select(m => new FrequencyData() { StatTime = m.StatTime.ToString("yyyy-MM-dd HH:mm:ss"), Frequency = m.Frequency });
        }
    }
}
