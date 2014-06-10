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
        public Bus Bus { get; private set; }

        public FixedPriceJobOrderSaga(Bus bus)
        {
            if(bus==null)
            {
                throw new ArgumentNullException("bus");
            }
            Bus = bus;
        }

        protected override void ConfigureSagaMappings()
        {
            ConfigureMapping<ExtendFixedPriceJobOrderCommand>(msg => msg.JobOrderId);
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
            var repository = new Repository<FixedPriceJobOrder>();
            repository.Save(jobOrder);
            this.Id = jobOrder.Id;
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
            var repository = new Repository<FixedPriceJobOrder>();
            var jobOrder = repository.GetById(message.JobOrderId);
            jobOrder.Extend(message.NewDueDate, message.Price);
            repository.Save(jobOrder);
        }
    }
}
