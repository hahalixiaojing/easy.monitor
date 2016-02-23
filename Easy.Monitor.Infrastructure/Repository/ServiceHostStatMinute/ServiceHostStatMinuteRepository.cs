using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;
using Easy.Monitor.Model.ServiceHostStatMinute;
using Dapper;
namespace Easy.Monitor.Infrastructure.Repository.ServiceHostStatMinute
{
    public class ServiceHostStatMinuteRepository : IServiceHostStatMinuteRepository, IDao
    {
        public void Add(Model.ServiceHostStatMinute.ServiceHostStatMinute[] data)
        {
            using (var conn = Database.OpenMonitorDatabase())
            {
                var trans = conn.BeginTransaction();
                try
                {

                    string addsql = Sql.Add();
                    conn.Execute(addsql, data, trans);
                    trans.Commit();
                }
                catch(Exception e)
                {
                    trans.Rollback();
                }
            }
        }

        public DateTime? FindMaxStatTime(string host, string serviceName)
        {
            using (var conn = Database.OpenMonitorDatabase())
            {
                string sql = Sql.FindMaxStatTime(host, serviceName);
                return conn.ExecuteScalar<DateTime?>(sql);
            }
        }

        public void RemoveAll()
        {
            using (var conn = Database.OpenMonitorDatabase())
            {
                string sql = Sql.RemoveAll();
                conn.Execute(sql);
            }
        }

        public IEnumerable<Model.ServiceHostStatMinute.ServiceHostStatMinute> SelectBy(Query query)
        {
            using (var conn = Database.OpenMonitorDatabase())
            {
                var sql = Sql.SelectBy(query);

                return conn.Query<Model.ServiceHostStatMinute.ServiceHostStatMinute>(sql, query);
            }
        }
    }

}
