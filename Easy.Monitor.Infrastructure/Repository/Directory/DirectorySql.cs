using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Infrastructure.Repository.Directory
{
    static class DirectorySql
    {
        static string BaseSelectSql()
        {
            return @"SELECT id as Id, name as Name, 
	                provider_node_count as NodeCount    
                    FROM regisrer_directory";
        }

        public static string FindById(int id)
        {
            return string.Join(" ", BaseSelectSql(), "WHERE", "id=" + id);
        }
        public static string Select()
        {
            return string.Join(" ", BaseSelectSql(), "order by id desc");
        }
    }
}
