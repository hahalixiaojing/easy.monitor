using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Easy.Monitor.Application.Models.ServiceStatMinute
{
    public class FrequencyData
    {
        [JsonProperty("y")]
        public string StatTime { get; set; }
        [JsonProperty("responseFrequency")]
        public double ResponseFrequency { get; set; }
        [JsonProperty("requestFrequency")]
        public double RequestFrequency { get; set; }
        [JsonProperty("averageRequestTime")]
        public double AverageRequestTime { get; set; }
        [JsonProperty("averageResponseTime")]
        public double AverageResponseTime { get; set; }
    }
}
