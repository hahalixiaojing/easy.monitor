using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Model.StatMetaData
{
    public class Query
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        public String ServiceName { get; set; }
        /// <summary>
        /// 服务接口
        /// </summary>
        public string ApiPath { get; set; }
        public DateTime? StatTimeStart { get; set; }
        public DateTime? StatTimeEnd { get; set; }

        public Int32 PageIndex;
        public Int32 PageSize;
        public Int32 Limit
        {
            get { return this.PageSize; }
        }

        public Int32 Offset
        {
            get { return (this.PageIndex - 1) * this.PageSize; }
        }

    }
}
