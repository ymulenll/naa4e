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
            //throw new NotImplementedException();

        }

        void _Send<T>(T message) where T : Message
        {
            BootRegisteredSagas(message);
            DeliverMessageToAlreadyRunningSagas(message);
            DeliverMessageToRegisteredHandlers(message);
        }

        private void DeliverMessageToRegisteredHandlers<T>(T message)
        {
            Type messageType = message.GetType();
            var openInterface = typeof(IHandleMessage<>);
            var closedInterface = openInterface.MakeGenericType(messageType);
            var handlersToNotify = from h in registeredHandlers.Values
                                 where closedInterface.IsAssignableFrom(h)
                                 select h;
            foreach(var h in handlersToNotify)
            {
                dynamic handlerInstance = Container.Resolve(h);
                handlerInstance.Handle(message);
            }
        }

        private void BootRegisteredSagas<T>(T message)
        {
            Type messageType = message.GetType();
            var openInterface = typeof(IAmStartedBy<>);
            var closedInterface = openInterface.MakeGenericType(messageType);
            var sagasToStartup = from s in registeredSagas.Values
                                 where closedInterface.IsAssignableFrom(s)
                                 select s;
            foreach (var s in sagasToStartup)
            {
                dynamic sagaInstance = Container.Resolve(s);
                sagaInstance.Handle(message);
            }
        }

        private void DeliverMessageToAlreadyRunningSagas<T>(T message)
        {
            Type messageType = message.GetType();
            var openInterface = typeof(IHandleMessage<>);
            var closedInterface = openInterface.MakeGenericType(messageType);
            var sagasToNotify = from s in registeredSagas.Values
                                 where closedInterface.IsAssignableFrom(s)
                                 select s;
            foreach (var s in sagasToNotify)
            {
                dynamic sagaInstance = Container.Resolve(s);
                sagaInstance.Handle(message);
            }
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
