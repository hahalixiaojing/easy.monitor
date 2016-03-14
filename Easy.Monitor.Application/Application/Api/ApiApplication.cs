using System;
using System.Collections.Generic;
using System.Linq;
using Easy.Domain.Application;
using Easy.Monitor.Application.Models.Api;
using Easy.Monitor.Model;

namespace Easy.Monitor.Application.Application.Api
{
    public class ApiApplication : BaseApplication
    {
        public IEnumerable<ApiModel> Select(int serviceId)
        {
            return RepositoryRegistry.Api.Select(serviceId).Select(m => new ApiModel()
            {
                Id = m.Id,
                Name = m.Name
            });
        }
    }
}
