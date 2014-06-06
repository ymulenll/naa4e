using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public class Bus : IBus
    {
        private static IList<SagaFactoryWrapper> sagaFactoryWrappers;
        public static void RegisterHandler<T>(Func<T> factory)
        {
            if (sagaFactoryWrappers == null)
            {
                sagaFactoryWrappers = new List<SagaFactoryWrapper>();
            }
            sagaFactoryWrappers.Add(new SagaFactoryWrapper<T>(factory));
        }

        public static void RegisterSaga<T>(Func<T> factory)
        {
            if (sagaFactoryWrappers == null)
            {
                sagaFactoryWrappers = new List<SagaFactoryWrapper>();
            }
            sagaFactoryWrappers.Add(new SagaFactoryWrapper<T>(factory));
        }

        private static void _Send<T>(T message) where T : Message
        {
            if (sagaFactoryWrappers != null)
            {
                foreach (var s in sagaFactoryWrappers)
                {
                    if (s.Handles<T>())
                    {
                        var saga = s.CreateInstance<T>();
                        saga.Handle(message);
                    }
                }
            }
        }

        public static void Send<T>(T command) where T : Command
        {
            _Send(command);
        }

        public static void RaiseEvent<T>(T @event) where T : DomainEvent
        {
            _Send(@event);
        }

        private static IList<Type> registeredSagas = new List<Type>();

        void IBus.RegisterSaga<T>()
        {
            Type sagaType = typeof(T);
            if(registeredSagas.Contains(sagaType))
            {
                throw new InvalidOperationException("The specified saga is already registered.");
            }
            registeredSagas.Add(sagaType);
        }

        void __Send<T>(T message) where T : Message
        {

        }

        void IBus.Send<T>(T command)
        {
            this.__Send(command);
        }

        void IBus.RaiseEvent<T>(T @event)
        {
            this.__Send(@event);
        }
    }
}
