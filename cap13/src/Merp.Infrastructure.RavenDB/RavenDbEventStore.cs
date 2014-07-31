using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure.RavenDB
{
    public class RavenDbEventStore : IEventStore
    {
        private static EmbeddableDocumentStore DocumentStore { get; set; }
        static RavenDbEventStore()
        {
            DocumentStore = new EmbeddableDocumentStore
            {
                ConnectionStringName = "EventStore"
                //UseEmbeddedHttpServer = true
            };
            DocumentStore.Conventions.AllowQueriesOnId = true; //Fix this
            DocumentStore.Initialize();
        }
        public IEnumerable<T> Find<T>() where T : DomainEvent
        {
            using (var session = DocumentStore.OpenSession())
            {
                var events = session.Query<T>();
                return events;
            }
        }

        public void Save<T>(T @event) where T : DomainEvent
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(@event);
                session.SaveChanges();
            }
        }
    }
}
