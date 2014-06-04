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
    public sealed class JobOrderLifetimeManager : IHandleMessage<CreateFixedPriceJobOrderCommand>
    {
        public Bus Bus { get; private set; }

        public JobOrderLifetimeManager(Bus bus)
        {
            if(bus==null)
            {
                throw new ArgumentNullException("bus");
            }
            Bus = bus;
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
            var @event = new FixedPriceJobOrderCreated(
                jobOrder.Id,
                jobOrder.CustomerId,
                jobOrder.Price,
                jobOrder.DateOfStart,
                jobOrder.DueDate,
                jobOrder.Name
                );
            Bus.RaiseEvent(@event);
        }
    }
}
