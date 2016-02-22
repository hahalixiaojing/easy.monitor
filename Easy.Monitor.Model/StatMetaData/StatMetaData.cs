using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Model.StatMetaData
{
    /// <summary>
    /// 统计元数据（分钟）
    /// </summary>
    public class StatMetaData
    {
        public StatMetaData()
        {

        }
        public StatMetaData(string serviceName, string ip, string apiUrl, string baseApiUrl, string apiPath,
            int frequency,
            int maxResponseTime,
            int minResponseTime,
            double averageResponseTime,
            DateTime statTime)
        {
            this.ServiceName = serviceName;
            this.Ip = ip;
            this.ApiUrl = apiUrl;
            this.BaseApiUrl = baseApiUrl;
            this.ApiPath = apiPath;
            this.Frequency = frequency;
            this.MaxResponseTime = maxResponseTime;
            this.MinResponseTime = minResponseTime;
            this.AverageResponseTime = averageResponseTime;
            this.StatTime = statTime;
        }
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName
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
        /// 接口基地址 provider
        /// </summary>
        public string BaseApiUrl
        {
            get;
            set;
        }
        /// <summary>
        /// API地址
        /// </summary>
        public string ApiUrl
        {
            get; set;
        }

        /// <summary>
        ///接口
        /// </summary>
        public string ApiPath
        {
            get;
            set;
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
