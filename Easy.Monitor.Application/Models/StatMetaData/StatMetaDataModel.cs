﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Application.Models.StatMetaData
{
    public class StatMetaDataModel
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName;
        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip;
        /// <summary>
        /// 接口基地址 provider
        /// </summary>
        public string BaseApiUrl;
        /// <summary>
        /// API地址
        /// </summary>
        public string ApiUrl;
        /// <summary>
        ///接口
        /// </summary>
        public string ApiPath;
        /// <summary>
        /// 每分钟请求数量
        /// </summary>
        public int Frequency;
        /// <summary>
        /// 请最大响应时间
        /// </summary>
        public int MaxResponseTime;
        /// <summary>
        /// 请求最小响应时间
        /// </summary>
        public int MinResponseTime;
        /// <summary>
        /// 请求平均响应时间
        /// </summary>
        public double AverageResponseTime;
        /// <summary>
        /// 统计时间
        /// </summary>
        public String StatTime;
    }
}
