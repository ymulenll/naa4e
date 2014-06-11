using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public class BusImpl : IBus
    {
        private static IDictionary<Message, Type> registeredSagas = new Dictionary<Message, Type>();

        void IBus.RegisterSaga<T>()
        {
            Type sagaType = typeof(T);
            if(sagaType.GetInterfaces().Where(i => i.Name.StartsWith(typeof(IAmStartedBy<>).Name)).Count() != 1)
            {
                throw new InvalidOperationException("The specified saga must implement the IAmStartedBy<T> interface.");
            }
            var ii = sagaType.GetInterfaces().Where(i => i.Name.StartsWith(typeof(IAmStartedBy<>).Name)).First();
            var messageType = ii.GenericTypeArguments.First();
        }

        void _Send<T>(T message) where T : Message
        {
            
        }

        void IBus.Send<T>(T command)
        {
            this._Send(command);
        }

        void IBus.RaiseEvent<T>(T @event)
        {
            this._Send(@event);
        }
    }
}
