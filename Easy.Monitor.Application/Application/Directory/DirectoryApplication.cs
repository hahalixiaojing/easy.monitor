using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Monitor.Application.Models.Directory;

namespace Easy.Monitor.Application.Application.Directory
{
    public class DirectoryApplication : BaseApplication
    {
        public IEnumerable<DirectoryModel> Select()
        {
            return Model.RepositoryRegistry.Directory.Select().Select(m => new DirectoryModel()
            {
                Id= m.Id,
                Name = m.Name,
                NodeCount = m.NodeCount
            });
        }
        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DirectoryModel FindById(int id)
        {
            var model = Model.RepositoryRegistry.Directory.FindById(id);

            return new DirectoryModel()
            {
                Id = model.Id,
                Name = model.Name,
                NodeCount = model.NodeCount
            };
        }
    }
}
