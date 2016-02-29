using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Model.ServiceHostStatMinute
{
    public class StatDataFillService
    {
        /// <summary>
        /// 填充没有统计到的时间点
        /// </summary>
        /// <param name="originalDataList"></param>
        /// <returns></returns>
        public IEnumerable<ServiceHostStatMinute> Fill(DateTime startDate, IEnumerable<ServiceHostStatMinute> originalDataList)
        {
            startDate = DateTime.Parse(startDate.ToString("yyyy-MM-dd HH:mm:00"));

            var filledDataList = new List<ServiceHostStatMinute>();
            for (var i = 2; i <= 31; i++)
            {
                var item = originalDataList.FirstOrDefault(m => m.StatTime == startDate.AddMinutes(i * -1)) ?? new ServiceHostStatMinute() { StatTime = startDate.AddMinutes(i * -1) };
                filledDataList.Add(item);
            }
            return filledDataList;
        }
    }
}
