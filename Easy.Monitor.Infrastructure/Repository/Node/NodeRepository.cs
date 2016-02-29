using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;
using Easy.Monitor.Model.Node;
using Dapper;
namespace Easy.Monitor.Infrastructure.Repository.Node
{
    public class NodeRepository : INodeRepository, IDao
    {
        public IEnumerable<Model.Node.Node> SelectBy(int serviceId)
        {
            using (var conn = Database.OpenRegisterDatabase())
            {
                return conn.Query<Model.Node.Node>(Sql.Select(serviceId));
            }
        }
    }
}
