using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public interface IEventStore
    {
        void Save<T>(T @event) where T : DomainEvent;
    }
}
