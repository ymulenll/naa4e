using System;
using Raven.Client;
using Raven.Client.Embedded;

namespace WaterpoloScoring
{
    public class RavenDbConfig
    {
        private static IDocumentStore _instance;

        public static IDocumentStore Instance
        {
            get
            {
                if (_instance == null)
                    throw new InvalidOperationException("IDocumentStore not initialized.");
                return _instance;
            }
        }

        public static IDocumentStore Initialize()
        {
            _instance = new EmbeddableDocumentStore { ConnectionStringName = "RavenDB" };
            _instance.Initialize();
            return _instance;
        }
    }
}