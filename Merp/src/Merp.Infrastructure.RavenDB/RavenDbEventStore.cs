using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Database.Server;
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
            NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8080);
            DocumentStore = new EmbeddableDocumentStore
            {
                ConnectionStringName = "EventStore",
                UseEmbeddedHttpServer = true
                //Conventions =
                //{
                //    FindTypeTagName = type =>
                //    {
                //        if (typeof(DomainEvent).IsAssignableFrom(type))
                //            return "DomainEvents";
                //        return DocumentConvention.DefaultTypeTagName(type);
                //    },
                //    AllowQueriesOnId = true     //Fix this
                //}
            };
            DocumentStore.Configuration.Port = 8080;
            DocumentStore.Initialize();
        }
        public IEnumerable<T> Find<T>(Func<T, bool> filter) where T : DomainEvent
        {
            using (var session = DocumentStore.OpenSession())
            {
                var events = session.Query<T>().Where(filter);
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
