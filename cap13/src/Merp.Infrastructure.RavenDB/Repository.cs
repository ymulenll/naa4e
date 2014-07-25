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
                ConnectionStringName = "DocumentStore"
                //UseEmbeddedHttpServer = true
            };
            DocumentStore.Initialize();
        }

        public IBus Bus { get; private set; }

        public Repository(IBus bus)
        {
            if (bus == null)
            {
                throw new ArgumentNullException("bus");
            }
            Bus = bus;
        }

        public T GetById<T>(Guid id) where T : IAggregate
        {
            using (var session = DocumentStore.OpenSession())
            {
                var item = (from i in session.Query<T>()
                            where i.Id == id
                            select i).Single();
                return item;
            }        
        }

        public void Save<T>(T item) where T : IAggregate
        {
            PersistAggregate(item);
            ManageUncommittedEvents(item);
        }
        private void PersistAggregate<T>(T item) where T : IAggregate
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(item);
            }
        }

        private void ManageUncommittedEvents<T>(T item) where T : IAggregate
        {
            item.GetUncommittedEvents()
                .ToList()
                .ForEach(e => Bus.RaiseEvent(e));
            item.ClearUncommittedEvents();
        }
    }
}
