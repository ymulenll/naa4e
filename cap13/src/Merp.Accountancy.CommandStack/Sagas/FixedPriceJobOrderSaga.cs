using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merp.Infrastructure;
using Merp.Accountancy.CommandStack.Commands;
using Merp.Accountancy.CommandStack.Model;
using Merp.Accountancy.CommandStack.Events;


namespace Merp.Accountancy.CommandStack.Sagas
{
    public sealed class FixedPriceJobOrderSaga : Saga,
        IAmStartedBy<CreateFixedPriceJobOrderCommand>,
        IHandleMessage<ExtendFixedPriceJobOrderCommand>
    {

        public FixedPriceJobOrderSaga(IBus bus, IEventStore eventStore, IRepository repository)
            : base(bus, eventStore, repository)
        {

        }

        public void Handle(CreateFixedPriceJobOrderCommand message)
        {
            var jobOrder = FixedPriceJobOrder.Factory.CreateNewInstance(
                message.CustomerId,
                message.Price, 
                message.DateOfStart, 
                message.DueDate,
                message.JobOrderName
                ); 
            this.Repository.Save(jobOrder);
            var @event = new FixedPriceJobOrderCreatedEvent(
                jobOrder.Id,
                jobOrder.CustomerId,
                jobOrder.Price,
                jobOrder.DateOfStart,
                jobOrder.DueDate,
                jobOrder.Name,
                jobOrder.Number
                );
            Bus.RaiseEvent(@event);
        }

        public void Handle(ExtendFixedPriceJobOrderCommand message)
        {
            var jobOrder = Repository.GetById<FixedPriceJobOrder>(message.JobOrderId);
            jobOrder.Extend(message.NewDueDate, message.Price);
            Repository.Save(jobOrder);
        }
    }
}
