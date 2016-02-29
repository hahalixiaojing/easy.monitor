using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Monitor.Model.Node
{
    public class Node : IEntity<int>
    {
        public int Id
        {
            get;private set;
        }
        /// <summary>
        /// API地址
        /// </summary>
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip
        {
            get;
            set;
        }
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName
        {
            get; set;
        }
    }
}
