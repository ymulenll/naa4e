using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public class BusImpl : IBus
    {
        private static IDictionary<Type, Type> registeredSagas = new Dictionary<Type, Type>();
        private static IDictionary<Guid, Saga> runningSagas = new Dictionary<Guid, Saga>();

        void IBus.RegisterSaga<T>()
        {
            Type sagaType = typeof(T);
            if(sagaType.GetInterfaces().Where(i => i.Name.StartsWith(typeof(IAmStartedBy<>).Name)).Count() != 1)
            {
                throw new InvalidOperationException("The specified saga must implement the IAmStartedBy<T> interface.");
            }
            var messageType = sagaType.
                GetInterfaces().
                Where(i => i.Name.StartsWith(typeof(IAmStartedBy<>).Name)).
                First().
                GenericTypeArguments.
                First();
            registeredSagas.Add(messageType, sagaType);
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
