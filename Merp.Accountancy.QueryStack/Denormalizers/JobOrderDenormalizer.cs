using Merp.Accountancy.CommandStack.Events;
using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack.Model
{
    public class JobOrderDenormalizer : IHandleMessage<FixedPriceJobOrderCreatedEvent>
    {
        public void Handle(FixedPriceJobOrderCreatedEvent message)
        {
            var fixedPriceJobOrder = new FixedPriceJobOrder();
            fixedPriceJobOrder.CustomerId = message.CustomerId;
            fixedPriceJobOrder.DateOfStart = message.DateOfStart;
            fixedPriceJobOrder.DueDate = message.DueDate;
            fixedPriceJobOrder.IsCompleted = message.IsCompleted;
            fixedPriceJobOrder.Name = message.JobOrderName;
            fixedPriceJobOrder.Number = string.Empty;
            fixedPriceJobOrder.Price = message.Price;
            
            using(var db = new MerpContext())
            {
                db.JobOrders.Add(fixedPriceJobOrder);
                db.SaveChanges();
            }
        }
    }
}
