using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;

namespace Easy.Monitor.Application.Application.Node
{
    public class NodeApplication : BaseApplication
    {
        public IEnumerable<Models.Node.Node> Select(int serviceId)
        {
            return Model.RepositoryRegistry.Node.SelectBy(serviceId).Select(m => new Models.Node.Node()
            {
                Id = m.Id,
                Url = m.Url,
                Ip = m.Ip,
                ServiceName =m.ServiceName
            });
        }
    }
}
