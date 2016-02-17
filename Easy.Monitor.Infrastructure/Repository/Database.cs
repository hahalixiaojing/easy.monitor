using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Easy.Monitor.Infrastructure.Repository
{
    static class Database
    {
        private static readonly string RegisterDatabase = ConfigurationManager.ConnectionStrings["register_database"].ConnectionString;
        private static readonly string MonitorDatabase = ConfigurationManager.ConnectionStrings["monitor_database"].ConnectionString;

        /// <summary>
        /// 打开注册中心数据库
        /// </summary>
        /// <returns></returns>
        public static IDbConnection OpenRegisterDatabase()
        {
            var db = new MySqlConnection(RegisterDatabase);
            db.Open();
            return db;
        }

        public static IDbConnection OpenStatDatabase()
        {
            var db = new MySqlConnection(MonitorDatabase);
            db.Open();
            return db;
        }
    }
}
