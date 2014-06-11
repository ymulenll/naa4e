using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure.Impl
{
    public class InMemoryBus : IBus
    {
        public IUnityContainer Container {get; private set;}

        private static IDictionary<Type, Type> registeredSagas = new Dictionary<Type, Type>();
        private static IDictionary<Type, Type> registeredHandlers = new Dictionary<Type, Type>();

        public InMemoryBus(IUnityContainer container)
        {
            if(container==null)
            {
                throw new ArgumentNullException("container");
            }
            Container = container;
        }

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

        void IBus.RegisterHandler<T>()
        {
            throw new NotImplementedException();
        }

        void _Send<T>(T message) where T : Message
        {
            //var sagas = registeredSagas.Values
            //                .Where(i => i.Name.StartsWith(typeof(IHandleMessage<>).Name))
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
