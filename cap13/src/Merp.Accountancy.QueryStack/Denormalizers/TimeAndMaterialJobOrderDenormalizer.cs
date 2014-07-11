using Merp.Accountancy.CommandStack.Events;
using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack.Model
{
    public class TimeAndMaterialJobOrderDenormalizer : 
        IHandleMessage<TimeAndMaterialJobOrderCreatedEvent>
    {
        public void Handle(TimeAndMaterialJobOrderCreatedEvent message)
        {
            var timeAndMaterialJobOrder = new TimeAndMaterialJobOrder();
            timeAndMaterialJobOrder.OriginalId = message.JobOrderId;
            timeAndMaterialJobOrder.CustomerId = message.CustomerId;
            timeAndMaterialJobOrder.DateOfStart = message.DateOfStart;
            timeAndMaterialJobOrder.DateOfExpiration = message.dateOfExpiration;
            timeAndMaterialJobOrder.Name = message.JobOrderName;
            timeAndMaterialJobOrder.Number = message.JobOrderNumber;
            timeAndMaterialJobOrder.HourlyFee = message.HourlyFee;
            timeAndMaterialJobOrder.IsCompleted = false;
            timeAndMaterialJobOrder.IsTimeAndMaterial = true;
            timeAndMaterialJobOrder.IsFixedPrice = false;

            using(var db = new MerpContext())
            {
                db.JobOrders.Add(timeAndMaterialJobOrder);
                db.SaveChanges();
            }
        }

        //public void Handle(FixedPriceJobOrderExtendedEvent message)
        //{
        //    using(var db = new MerpContext())
        //    {
        //        var jobOrder = db.JobOrders.Select(jo => jo.Id).OfType<FixedPriceJobOrder>().Single();
        //        jobOrder.DueDate = message.NewDueDate;
        //        jobOrder.Price = message.Price;
        //        db.SaveChanges();
        //    }
        //}
    }
}
