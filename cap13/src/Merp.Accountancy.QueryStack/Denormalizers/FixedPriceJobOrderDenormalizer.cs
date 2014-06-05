using Merp.Accountancy.CommandStack.Events;
using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack.Model
{
    public class FixedPriceJobOrderDenormalizer : 
        IHandleMessage<FixedPriceJobOrderCreatedEvent>,
        IHandleMessage<FixedPriceJobOrderExtendedEvent>
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

        public void Handle(FixedPriceJobOrderExtendedEvent message)
        {
            using(var db = new MerpContext())
            {
                var jobOrder = db.JobOrders.Select(jo => jo.Id).OfType<FixedPriceJobOrder>().Single();
                jobOrder.DueDate = message.NewDueDate;
                jobOrder.Price = message.Price;
                db.SaveChanges();
            }
        }
    }
}
