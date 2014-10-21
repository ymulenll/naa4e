using System;
using System.Collections.Generic;
using WaterpoloScoring.Backend.DAL;

namespace WaterpoloScoring.Framework
{
    public class Bus
    {
        private static readonly Dictionary<Type, Type> SagaStarters = new Dictionary<Type, Type>();
        private static readonly Dictionary<string, object> SagaInstances = new Dictionary<string, object>();

        public static void RegisterSaga<TStartMessage, TSaga>()
        {
            SagaStarters.Add(typeof(TStartMessage), typeof(TSaga));
        }

        public static void Send<T>(T message) where T : Message
        {
            // Check if the message can start one of the registered sagas
            if (SagaStarters.ContainsKey(typeof(T)))
            {
                // Start the saga creating a new instance of the type
                var typeOfSaga = SagaStarters[typeof(T)];
                var instance = (IStartWithMessage<T>)Activator.CreateInstance(typeOfSaga);
                instance.Handle(message);

                // At this point the saga has been given an ID; 
                // let's persist the instance to a (memory) dictionary for later use.
                SagaInstances[instance.SagaId] = instance;
            }

            // The message doesn’t start any saga.
            // Check if the message can be delivered to an existing saga instead
            if (message.SagaId == null)
                return;

            if (SagaInstances.ContainsKey(message.SagaId))
            {
                // Check compatibility between saga and message: can the saga handle THIS message?
                var sagaType = SagaInstances[message.SagaId].GetType();
                if (!typeof(ICanHandleMessage<T>).IsAssignableFrom(sagaType))
                    return;

                var saga = (ICanHandleMessage<T>)SagaInstances[message.SagaId];
                saga.Handle(message);

                // Saves saga back or remove if completed
                //if (saga.IsComplete())
                //    SagaInstances.Remove(message.Id);
                //else
                //    SagaInstances[message.Id] = saga;
            }

            // Publish the event 
            if (message is DomainEvent)
            {
                // Invoke all registered sagas and give each 
                // a chance to handle the event.
                foreach (var sagaEntry in SagaInstances)
                {
                    var sagaType = sagaEntry.Value.GetType();
                    if (!typeof(ICanHandleMessage<T>).IsAssignableFrom(sagaType))
                        return;

                    // Give other sagas interested in the event a chance to handle it.
                    // Current saga already had its chance to handle the event.
                    var handler = (ICanHandleMessage<T>)sagaEntry.Value;
                    if (sagaEntry.Key != message.SagaId)
                        handler.Handle(message);
                }
            }
        }
    }

}