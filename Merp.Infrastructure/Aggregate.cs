using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public abstract class Aggregate
    {
        public Guid Id { get; protected set; }

        private IList<DomainEvent> uncommittedEvents = new List<DomainEvent>();

        public bool IsChanged 
        { 
            get 
            { 
                return this.uncommittedEvents.Any();  
            } 
        }

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
