using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public interface IBus
    {
        void Send<T>(T command) where T : Command;

        void RaiseEvent<T>(T @event) where T : DomainEvent;
    }
}
