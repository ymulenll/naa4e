using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public class BusImpl : IBus
    {
        private static IList<Type> registeredSagas = new List<Type>();

        void IBus.RegisterSaga<T>()
        {
            Type sagaType = typeof(T);
            if (registeredSagas.Contains(sagaType))
            {
                throw new InvalidOperationException("The specified saga is already registered.");
            }
            registeredSagas.Add(sagaType);
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
