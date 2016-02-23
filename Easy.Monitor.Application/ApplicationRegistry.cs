using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Monitor.Application.Application.ServiceStatMinute;
using Easy.Monitor.Application.Application.StatMetaData;

namespace Easy.Monitor.Application
{
    public static class ApplicationRegistry
    {
        static ApplicationRegistry()
        {
            ApplicationFactory.Instance().Register(new StatMetaDataApplication());
            ApplicationFactory.Instance().Register(new ServiceStatMinuteApplication());

        }


        public static ServiceStatMinuteApplication ServiceStatMinute
        {
            get
            {
                return ApplicationFactory.Instance().Get<ServiceStatMinuteApplication>();
            }
        }
        public static StatMetaDataApplication StatMetaData
        {
            get
            {
                return ApplicationFactory.Instance().Get<StatMetaDataApplication>();
            }
        }
    }
}
