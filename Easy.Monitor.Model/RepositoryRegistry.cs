﻿
using System;
using System.IO;
using System.Reflection;
using Easy.Domain.RepositoryFramework;
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

        public static IStatMetaDataRepository StatMetaData
        {
            get
            {
                return factory.Get<IStatMetaDataRepository>();
            }
        }
    }
}
