using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Easy.Monitor.Test.Repository.ServiceHostStatMinute
{
    public class ServiceHostStatMinuteRepositoryTest
    {
        [Test]
        public void FindMaxStatTime()
        {
            var m = Create();

            DateTime? datetime = Model.RepositoryRegistry.ServiceHostStatMinute.FindMaxStatTime(m.ServiceName);
            Assert.IsNull(datetime);

            Model.RepositoryRegistry.ServiceHostStatMinute.Add(new Model.ServiceHostStatMinute.ServiceHostStatMinute[1] { m });

            datetime = Model.RepositoryRegistry.ServiceHostStatMinute.FindMaxStatTime(m.ServiceName);
            Assert.IsNotNull(datetime);
        }

        [Test]
        public void AddTest()
        {
            var m = Create();

            Model.RepositoryRegistry.ServiceHostStatMinute.Add(new Model.ServiceHostStatMinute.ServiceHostStatMinute[1] { m });

            var result = Model.RepositoryRegistry.ServiceHostStatMinute.SelectBy(new Easy.Monitor.Model.ServiceHostStatMinute.Query());

            Assert.IsTrue(result.Count() > 0);

        }
        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.ServiceHostStatMinute.RemoveAll();
        }

        public Model.ServiceHostStatMinute.ServiceHostStatMinute Create()
        {
            var m = new Model.ServiceHostStatMinute.ServiceHostStatMinute()
            {
                AverageResponseTime = 1.2,
                ResponseFrequency = 1,
                MaxResponseTime = 1,
                MinResponseTime = 1,
                ServiceName = "dfsdf",
                StatTime = DateTime.Now,
                Host = "192.168.100.200:3399",
                TotalResponseTime = 10000
            };
            return m;

        }
    }
}
