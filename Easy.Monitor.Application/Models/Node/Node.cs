using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Application.Models.Node
{
    public class Node
    {
        public int Id;
        /// <summary>
        /// API地址
        /// </summary>
        public string Url;

        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip;
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName;
    }
}
