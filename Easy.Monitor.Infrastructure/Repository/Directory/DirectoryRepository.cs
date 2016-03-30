using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Monitor.Model.Directory;
using Dapper;
using Easy.Domain.RepositoryFramework;

namespace Easy.Monitor.Infrastructure.Repository.Directory
{
    public class DirectoryRepository : IDirectoryRepository,IDao
    {
        public IEnumerable<Model.Directory.Directory> Select()
        {
            using (var conn = Database.OpenRegisterDatabase())
            {
                string sql = DirectorySql.Select();
                return conn.Query<Model.Directory.Directory>(sql);
            }
        }

        public Model.Directory.Directory FindById(int id)
        {
            using(var conn = Database.OpenRegisterDatabase())
            {
                string sql = DirectorySql.FindById(id);
                return conn.Query<Model.Directory.Directory>(sql).FirstOrDefault();
            }
        }
    }
}
