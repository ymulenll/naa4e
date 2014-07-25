using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merp.Infrastructure;
using Raven.Client.Embedded;

namespace Merp.Infrastructure.RavenDB
{
    public class Repository : IRepository
    {
        private static EmbeddableDocumentStore DocumentStore { get; set; }
        static Repository()
        {
            DocumentStore = new EmbeddableDocumentStore
            {
                DataDirectory = "App_Data",
                UseEmbeddedHttpServer = true
            };
        }

        public T GetById<T>(Guid id) where T : IAggregate
        {
            throw new NotImplementedException();
        }

        public void Save<T>(T item) where T : IAggregate
        {
            throw new NotImplementedException();
        }
    }
}
