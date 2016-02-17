using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;
using Easy.Monitor.Model.StatMetaData;

namespace Easy.Monitor.Infrastructure.Repository.StatMetaData
{
    public class StatMetaDataRepository : IStatMetaDataRepository, IDao
    {
        public void Add(Model.StatMetaData.StatMetaData[] data)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.StatMetaData.StatMetaData> SelectBy(Query query)
        {
            throw new NotImplementedException();
        }
    }
}
