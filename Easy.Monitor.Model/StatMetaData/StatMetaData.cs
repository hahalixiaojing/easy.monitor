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
        public StatMetaData(string serviceName,string ip,string baseApiUrl,string apiPah,
            int frequency,
            double maxResponseTime,
            double minResponseTime,
            double averageResponseTime,
            int year,
            int month,
            int day,
            int hour,
            int minute)
        {
            this.ServiceName = serviceName;
            this.Ip = ip;
            this.BaseApiUrl = baseApiUrl;
            this.ApiPath = apiPah;
            this.Frequency = frequency;
            this.MaxResponseTime = maxResponseTime;
            this.MinResponseTime = minResponseTime;
            this.AverageResponseTime = averageResponseTime;
            this.Year = year;
            this.Month = month;
            this.Day = day;
            this.Hour = hour;
            this.Minute = minute;
        }
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName
        {
            get;
            private set;
        }
        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip
        {
            get;
            private set;
        }
        /// <summary>
        /// 接口基地址 provider
        /// </summary>
        public string BaseApiUrl
        {
            get;
            private set;
        }
        /// <summary>
        ///接口
        /// </summary>
        public string ApiPath
        {
            get;
            private set;
        }
        /// <summary>
        /// 每分钟请求数量
        /// </summary>
        public int Frequency
        {
            get;
            private set;
        }
        /// <summary>
        /// 请最大响应时间
        /// </summary>
        public double MaxResponseTime
        {
            get;
            private set;
        }
        /// <summary>
        /// 请求最小响应时间
        /// </summary>
        public double MinResponseTime
        {
            get;
            private set;
        }
        /// <summary>
        /// 请求平均响应时间
        /// </summary>
        public double AverageResponseTime
        {
            get;
            private set;
        }
        /// <summary>
        /// 统计年份
        /// </summary>
        public int Year
        {
            get;
            private set;
        }
        /// <summary>
        /// 统计月份
        /// </summary>
        public int Month
        {
            get;
            private set;
        }
        /// <summary>
        /// 统计日期
        /// </summary>
        public int Day
        {
            get;
            private set;
        }
        /// <summary>
        /// 统计分钟
        /// </summary>
        public int Hour
        {
            get;
            private set;
        }
        /// <summary>
        /// 统时分钟
        /// </summary>
        public int Minute
        {
            get;
            private set;
        }
    }
}
