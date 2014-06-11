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
