using Merp.Accountancy.CommandStack.Events;
using Merp.Accountancy.CommandStack.Services;
using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.CommandStack.Model
{
    public class FixedPriceJobOrder : JobOrder
    {
        //public decimal Price { get; private set; }
        public DateTime DueDate { get; private set; }
        public PositiveMoney Price { get; private set; }
        protected FixedPriceJobOrder()
        {
            
        }

        public void Apply(FixedPriceJobOrderExtendedEvent evt)
        {
            this.DueDate = evt.NewDueDate;
            this.Price = new PositiveMoney(evt.Price, this.Price.Currency);
        }

        public void Apply(FixedPriceJobOrderCompletedEvent evt)
        {
            this.DateOfCompletion = evt.DateOfCompletion;
            this.IsCompleted = true;
        }

        public void Apply(FixedPriceJobOrderRegisteredEvent evt)
        {
            Id = evt.JobOrderId;
            Customer = new CustomerInfo(evt.CustomerId, evt.CustomerName);
            Manager = new ManagerInfo(evt.ManagerId, evt.ManagerName);
            Price = new PositiveMoney(evt.Price, evt.Currency);
            DateOfStart= evt.DateOfStart;
            DueDate=evt.DueDate;
            Name = evt.JobOrderName;
            Number = evt.JobOrderNumber; 
            IsCompleted = false;
            PurchaseOrderNumber = evt.PurchaseOrderNumber;
            Description = evt.Description;
        }

        public void Extend(DateTime newDueDate, decimal price)
        {
            var @event = new FixedPriceJobOrderExtendedEvent(
                this.Id, 
                newDueDate,
                price
            );
            RaiseEvent(@event);
        }

        public void MarkAsCompleted(DateTime dateOfCompletion)
        {
            if(this.DateOfStart > dateOfCompletion)
            {
                throw new ArgumentException("The date of completion cannot precede the date of start.", "dateOfCompletion");
            }
            if(this.IsCompleted)
            {
                throw new InvalidOperationException("The Job Order has already been marked as completed");
            }
            var @event = new FixedPriceJobOrderCompletedEvent(
                this.Id,
                dateOfCompletion
            );
            RaiseEvent(@event);
        }

        public class Factory
        {
            public static FixedPriceJobOrder CreateNewInstance(IJobOrderNumberGenerator jobOrderNumberGenerator, Guid customerId, string customerName, Guid managerId, string managerName, decimal price, string currency, DateTime dateOfStart, DateTime dueDate, string name, string purchaseOrderNumber, string description)
            { 
                var @event = new FixedPriceJobOrderRegisteredEvent(
                    Guid.NewGuid(),
                    customerId,
                    customerName,
                    managerId, 
                    managerName,
                    price,
                    currency,
                    dateOfStart,
                    dueDate,
                    name,
                    jobOrderNumberGenerator.Generate(),
                    purchaseOrderNumber,
                    description
                    );
                var jobOrder = new FixedPriceJobOrder();
                jobOrder.RaiseEvent(@event);
                return jobOrder;
            }
        }
    }
}
