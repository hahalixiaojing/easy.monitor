using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Monitor.Model.StatMetaData;

namespace Easy.Monitor.Model.ServiceStatMinute
{
    public interface IServiceStatMinuteRepository
    {
        void Add(ServiceStatMinute[] data);
        IEnumerable<ServiceStatMinute> SelectBy(Query query);
        void RemoveAll();
    }
}
