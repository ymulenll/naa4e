using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public class Repository : IRepository 
    {
        public void Save<T>(T item) where T : IAggregate
        {
            item.GetUncommittedEvents()
                .ToList()
                .ForEach(e => ManageEvent(e));
            item.ClearUncommittedEvents();
            //Persist aggregate snapshot   
        }

        private void ManageEvent(DomainEvent e)
        {
            //Save event
            //Notity event via the bus
        }

        public T GetById<T>(Guid id) where T : IAggregate
        {
            return default(T);
        }
    }
}
