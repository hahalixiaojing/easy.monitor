using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Easy.Monitor.Test.Repository.StatMetaData
{
    public class StatMetaDataRepositoryTest
    {
        [Test]
        public void AddTest()
        {
            var data = Create();
            Model.RepositoryRegistry.StatMetaData.Add(new Model.StatMetaData.StatMetaData[1] { data });
        }

        [Test]
        public void SelectByTest()
        {
            var data = Create();
            Model.RepositoryRegistry.StatMetaData.Add(new Model.StatMetaData.StatMetaData[1] { data });
            int totalRows;
            var list = Model.RepositoryRegistry.StatMetaData.SelectBy(new Model.StatMetaData.Query(),out totalRows);
            Assert.IsTrue(list.Any());

            list = Model.RepositoryRegistry.StatMetaData.SelectBy(new Model.StatMetaData.Query() { StatTimeStart = DateTime.Now.AddDays(1) }, out totalRows);
            Assert.IsTrue(!list.Any());


        }

        [Test]
        public void GetStatMetaDataCountTest()
        {
              var data = Create();
            Model.RepositoryRegistry.StatMetaData.Add(new Model.StatMetaData.StatMetaData[1] { data });
            var list = Model.RepositoryRegistry.StatMetaData.GetStatMetaDataCount(new Model.StatMetaData.Query());
            Assert.IsTrue(list>0);

        }

        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.StatMetaData.RemoveAll();
        }

        public Model.StatMetaData.StatMetaData Create()
        {
            return new Model.StatMetaData.StatMetaData("orderservice", "192.216.43.2", "http://werwe/s", "http://fsdfdsf.cm", "/create", 1, 1, 1, 2.2, 100, DateTime.Now, 1, 1, 1);
        }
    }
}
