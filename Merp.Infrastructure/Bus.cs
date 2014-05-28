using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public class Bus
    {
        private static IList<SagaFactoryWrapper> sagaFactoryWrappers;
        public static void RegisterSaga<T>(Func<T> factory)
        {
            if (sagaFactoryWrappers == null)
            {
                sagaFactoryWrappers = new List<SagaFactoryWrapper>();
            }
            sagaFactoryWrappers.Add(new SagaFactoryWrapper<T>(factory));
        }

        public static void _Send<T>(T message) where T : Message
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

        public static void Send(Command command)
        {
            _Send(command);
        }

        public static void RaiseEvent(DomainEvent @event)
        {
            _Send(@event);
        }
    }
}
