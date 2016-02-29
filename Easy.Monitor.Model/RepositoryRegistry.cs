
using System;
using System.IO;
using System.Reflection;
using Easy.Domain.RepositoryFramework;
using Easy.Monitor.Model.Directory;
using Easy.Monitor.Model.Node;
using Easy.Monitor.Model.ServiceHostStatMinute;
using Easy.Monitor.Model.ServiceStatMinute;
using Easy.Monitor.Model.StatMetaData;

namespace Easy.Monitor.Model
{
    public static class RepositoryRegistry
    {
        readonly static RepositoryFactory factory;
        static RepositoryRegistry()
        {
            RepositoryFactoryBuilder b = new RepositoryFactoryBuilder();

            string path = Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory, "Easy.Monitor.Infrastructure.dll");
            Stream stream = Assembly.ReflectionOnlyLoadFrom(path).GetManifestResourceStream("Easy.Monitor.Infrastructure.Repository.repository.xml");

            factory = b.Build(stream);
        }

        public static INodeRepository Node
        {
            get
            {
                return factory.Get<INodeRepository>();
            }
        }

        public static IServiceHostStatMinuteRepository ServiceHostStatMinute
        {
            get
            {
                return factory.Get<IServiceHostStatMinuteRepository>();
            }
        }

        public static IDirectoryRepository Directory
        {
            get
            {
                return factory.Get<IDirectoryRepository>();
            }
        }


        public static IStatMetaDataRepository StatMetaData
        {
            get
            {
                return factory.Get<IStatMetaDataRepository>();
            }
        }
        public static IServiceStatMinuteRepository ServiceStatMinute
        {
            get
            {
                return factory.Get<IServiceStatMinuteRepository>();
            }
        }
    }
}
