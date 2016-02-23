using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;

namespace Easy.Monitor.Application.Application.ServiceStatMinute
{
    public class ServiceStatMinuteApplication : BaseApplication
    {
        public void StartStat()
        {
            var serviceNames = Model.RepositoryRegistry.Directory.Select().Select(m => m.Name).ToArray();
            new Model.ServiceStatMinute.StatService().Stat(serviceNames);
        }
    }
}
