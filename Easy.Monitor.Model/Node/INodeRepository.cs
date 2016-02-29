using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Model.Node
{
    public interface INodeRepository
    {
        IEnumerable<Node> SelectBy(int serviceId);
    }
}