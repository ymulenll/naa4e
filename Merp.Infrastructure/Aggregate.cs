using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public class Aggregate
    {
        public Guid Id { get; protected set; }
        private IList<DomainEvent> uncommittedEvents = new List<DomainEvent>();

        public IEnumerable<DomainEvent> GetUncommittedEvents()
        {
            return uncommittedEvents.ToArray();
        }

        public void ClearUncommittedEvents()
        {
            uncommittedEvents.Clear();
        }

        public void RaiseEvent(DomainEvent @event)
        {
            uncommittedEvents.Add(@event);
        }
    }
}
