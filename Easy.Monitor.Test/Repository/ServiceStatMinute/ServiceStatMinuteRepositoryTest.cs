using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Easy.Monitor.Test.Repository.ServiceStatMinute
{
    public class ServiceStatMinuteRepositoryTest
    {
        [Test]
        public void FindMaxStatTime()
        {
            var m = Create();

            DateTime? datetime = Model.RepositoryRegistry.ServiceStatMinute.FindMaxStatTime(m.ServiceName);
            Assert.IsNull(datetime);

            Model.RepositoryRegistry.ServiceStatMinute.Add(new Model.ServiceStatMinute.ServiceStatMinute[1] { m });

            datetime = Model.RepositoryRegistry.ServiceStatMinute.FindMaxStatTime(m.ServiceName);
            Assert.IsNotNull(datetime);
        }

        [Test]
        public void AddTest()
        {
            var m = Create();

            Model.RepositoryRegistry.ServiceStatMinute.Add(new Model.ServiceStatMinute.ServiceStatMinute[1] { m });

            var result = Model.RepositoryRegistry.ServiceStatMinute.SelectBy(new Model.ServiceStatMinute.Query());

            Assert.IsTrue(result.Count() > 0);

        }
        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.ServiceStatMinute.RemoveAll();
        }

        public Model.ServiceStatMinute.ServiceStatMinute Create()
        {
            var m = new Model.ServiceStatMinute.ServiceStatMinute()
            {
                AverageResponseTime = 1.2,
                Frequency = 1,
                MaxResponseTime = 1,
                MinResponseTime = 1,
                ServiceName = "dfsdf",
                StatTime = DateTime.Now
            };
            return m;
            
        }
    }
}
