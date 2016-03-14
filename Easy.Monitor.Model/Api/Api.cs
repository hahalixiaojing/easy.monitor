using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Monitor.Model.Api
{
    /// <summary>
    /// API
    /// </summary>
    public class Api : IEntity<int>
    {
        /// <summary>
        /// apiID
        /// </summary>
        public int Id
        {
            get; private set;
        }
        /// <summary>
        /// api名称
        /// </summary>
        public string Name { get; private set; }
    }
}
