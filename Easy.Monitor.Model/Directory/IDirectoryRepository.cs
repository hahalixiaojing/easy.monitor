using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Monitor.Model.Directory
{
    public interface IDirectoryRepository
    {
        IEnumerable<Directory> Select();
        Directory FindById(int id);
    }
}
