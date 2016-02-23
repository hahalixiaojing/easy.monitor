using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Monitor.Model.Directory
{
    public class Directory : IEntity<int>
    {
        public int Id
        {
            get;
            private set;
        }
        public string Name
        {
            get; private set;
        }
        public int NodeCount
        {
            get;private set;
        }
    }
}
