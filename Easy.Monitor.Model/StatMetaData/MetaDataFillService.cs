using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Model.StatMetaData
{
    /// <summary>
    /// 整理数据
    /// </summary>
    public class MetaDataFillService
    {
        /// <summary>
        /// 填充没有统计到的时间点
        /// </summary>
        /// <param name="originalDataList"></param>
        /// <returns></returns>
        public IEnumerable<StatMetaData> Fill(DateTime startDate, IEnumerable<StatMetaData> originalDataList)
        {
            startDate = DateTime.Parse(startDate.ToString("yyyy-MM-dd HH:mm:00"));

            var filledDataList = new List<StatMetaData>();
            for (var i = 2; i <= 31; i++)
            {
                var item = originalDataList.FirstOrDefault(m => m.StatTime == startDate.AddMinutes(i * -1)) ?? new StatMetaData() { StatTime = startDate.AddMinutes(i * -1) };
                filledDataList.Add(item);
            }
            return filledDataList;
        }
    }
}
