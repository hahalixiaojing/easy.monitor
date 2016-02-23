using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Model.ServiceHostStatMinute
{
    public interface IServiceHostStatMinuteRepository
    {
        void Add(ServiceHostStatMinute[] data);
        IEnumerable<ServiceHostStatMinute> SelectBy(Query query);
        /// <summary>
        /// 获得当前最大的统计时间
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        DateTime? FindMaxStatTime(string serviceName);
        void RemoveAll();
    }
}
