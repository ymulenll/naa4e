using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure.Impl
{
    public class InMemoryEventStore : IEventStore
    {
        private static IList<DomainEvent> occurredEvents = new List<DomainEvent>();

        public IEnumerable<T> Find<T>() where T : DomainEvent
        {
            var events = (from e in occurredEvents
                         where e.GetType() == typeof(T)
                         select e).Cast<T>();
            return events;
        }

        public void Save<T>(T @event) where T : DomainEvent
        {
            occurredEvents.Add(@event);
        }
    }
}
