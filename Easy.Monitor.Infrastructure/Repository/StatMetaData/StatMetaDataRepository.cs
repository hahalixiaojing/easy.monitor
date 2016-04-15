using System;
using System.Collections.Generic;

using Easy.Domain.RepositoryFramework;
using Easy.Monitor.Model.StatMetaData;
using Dapper;
namespace Easy.Monitor.Infrastructure.Repository.StatMetaData
{
    public class StatMetaDataRepository : IStatMetaDataRepository, IDao
    {
        public void Add(Model.StatMetaData.StatMetaData[] data)
        {
            using(var conn = Database.OpenMonitorDatabase())
            {
                var tuple = Sql.Add(data);
                conn.Execute(tuple.Item1, tuple.Item2);
            }
        }

        public void RemoveAll()
        {
            using(var conn = Database.OpenMonitorDatabase())
            {
                conn.Execute(Sql.RemoveAll());
            }
        }

        public IEnumerable<Model.StatMetaData.StatMetaData> SelectBy(Query query, out int totalRows)
        {
            if (query.PageIndex <= 0)
            {
                query.PageIndex = 1;
            }
            if (query.PageSize <= 0)
            {
                query.PageSize = 100;
            }
            using (var conn = Database.OpenMonitorDatabase())
            {
                var tuple = Sql.SelectMetaDataCount(query);
                totalRows = conn.ExecuteScalar<int>(tuple.Item1, (object)tuple.Item2);
                return conn.Query<Model.StatMetaData.StatMetaData>(Sql.SelectByQuery(query), query);
            }
        }

        public int GetStatMetaDataCount(Query query)
        {
            using (var conn = Database.OpenMonitorDatabase())
            {
                var tuple = Sql.SelectMetaDataCount(query);
                 var result =conn.ExecuteScalar<int>(tuple.Item1, (object)tuple.Item2);
                 return result;
            }
        }
    }
}
