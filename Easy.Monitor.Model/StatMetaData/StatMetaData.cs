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
            int totalResponseTime,
            DateTime statTime,double averageRequestResponseTime,int errorResponseFrquency,int requestFrequency)
        {
            this.ServiceName = serviceName;
            this.Ip = ip;
            this.ApiUrl = apiUrl;
            this.BaseApiUrl = baseApiUrl;
            this.ApiPath = apiPath;
            this.ResponseFrequency = frequency;
            this.MaxResponseTime = maxResponseTime;
            this.MinResponseTime = minResponseTime;
            this.AverageResponseTime = averageResponseTime;
            this.TotalResponseTime = totalResponseTime;
            this.StatTime = statTime;
            this.AverageRequestResponseTime = averageRequestResponseTime;
            this.ErrorResponseFrquency = errorResponseFrquency;
            this.RequestFrequency = requestFrequency;
        }
        /// <summary>
        /// 每分钟请求平均响应时间
        /// </summary>
        public double AverageRequestResponseTime
        {
            get; set;
        }
        /// <summary>
        /// 错误请求次数
        /// </summary>
        public int ErrorResponseFrquency
        {
            get; set;
        }
        /// <summary>
        /// 请求次数
        /// </summary>
        public int RequestFrequency
        {
            get; set;
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
        /// 总响应时间
        /// </summary>
        public int TotalResponseTime
        {
            get; set;
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
        public int ResponseFrequency
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
