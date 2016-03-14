using System.Collections.Generic;
using Easy.Domain.RepositoryFramework;
using Easy.Monitor.Model.Api;
using Dapper;
namespace Easy.Monitor.Infrastructure.Repository.Api
{
    public class ApiRepository : IApiRepository, IDao
    {
        public IEnumerable<Model.Api.Api> Select(int serviceId)
        {
            using (var conn = Database.OpenRegisterDatabase())
            {
                return conn.Query<Model.Api.Api>(Sql.Select(serviceId));  
            }
        }
    }
}
