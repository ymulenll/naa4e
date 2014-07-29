using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure.Impl
{
    public class InMemoryEventStore : IEventStore
    {
        private IList<DomainEvent> events = new List<DomainEvent>();

        public void Save<T>(T @event) where T : DomainEvent
        {
            events.Add(@event);
        }
    }
}
