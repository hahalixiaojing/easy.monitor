using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Model.Api
{
    public interface IApiRepository
    {
        IEnumerable<Api> Select(int serviceId);
    }
}
