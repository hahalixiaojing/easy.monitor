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
        [JsonProperty("item1")]
        public int Frequency { get; set; }
    }
}
