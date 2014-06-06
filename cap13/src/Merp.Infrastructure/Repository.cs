using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public class Repository<T> where T : IAggregate
    {
        public void Save(T item)
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

        public T GetById(Guid id)
        {
            return default(T);
        }
    }
}
