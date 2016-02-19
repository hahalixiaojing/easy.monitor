using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Model.ServiceStatMinute
{
    /// <summary>
    /// 按服务维度统计（时间：分钟）
    /// </summary>
    public class ServiceStatMinute
    {


        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName
        {
            get; set;
        }
        /// <summary>
        /// 每分钟请求数量
        /// </summary>
        public int Frequency
        {
            get;
            set;
        }
        /// <summary>
        /// 请最大响应时间
        /// </summary>
        public int MaxResponseTime
        {
            get;
            set;
        }
        /// <summary>
        /// 请求最小响应时间
        /// </summary>
        public int MinResponseTime
        {
            get;
            set;
        }
        /// <summary>
        /// 请求平均响应时间
        /// </summary>
        public double AverageResponseTime
        {
            get;
            set;
        }
        /// <summary>
        /// 统计时间
        /// </summary>
        public DateTime StatTime
        {
            get; set;
        }

    }
}
