using System.Collections.Generic;

namespace Easy.Monitor.Model.StatMetaData
{
    public interface IStatMetaDataRepository
    {
        void Add(StatMetaData[] data);
        IEnumerable<StatMetaData> SelectBy(Query query);
        int GetStatMetaDataCount(Query query);
        void RemoveAll();
    }
}
