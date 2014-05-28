using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merp.Infrastructure;
using Merp.Accountancy.CommandStack.Commands;
using Merp.Accountancy.CommandStack.Model;


namespace Merp.Accountancy.CommandStack.Sagas
{
    public sealed class JobOrderLifetimeManager : IHandleMessage<StartFixedPriceJobOrderCommand>
    {
        public void Handle(StartFixedPriceJobOrderCommand message)
        {
            var jobOrder = FixedPriceJobOrder.Factory.CreateNewInstance(
                message.CustomerId,
                message.Price, 
                message.DateOfStart, 
                message.DueDate
                );
            var repository = new Repository<FixedPriceJobOrder>();
            repository.Save(jobOrder);
        }
    }
}
