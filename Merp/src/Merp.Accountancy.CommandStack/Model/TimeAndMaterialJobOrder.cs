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
    public class TimeAndMaterialJobOrder : JobOrder
    {
        public PositiveMoney Value { get; private set; }

        public DateTime? DateOfExpiration { get; private set; }

        protected TimeAndMaterialJobOrder()
        {
            
        }

        public void Apply(TimeAndMaterialJobOrderExtendedEvent evt)
        {
            this.DateOfExpiration = evt.NewDateOfExpiration;
            this.Value = new PositiveMoney(evt.Value, this.Value.Currency);
        }

        public void Apply(TimeAndMaterialJobOrderCompletedEvent evt)
        { 
            this.DateOfCompletion = evt.DateOfCompletion;
            this.IsCompleted = true;        
        }

        public void Apply(TimeAndMaterialJobOrderRegisteredEvent evt)
        {
            Id = evt.JobOrderId;
            Customer = new CustomerInfo(evt.CustomerId, evt.CustomerName);
            Manager = new ManagerInfo(evt.ManagerId, evt.ManagerName);
            Value = new PositiveMoney(evt.Value, evt.Currency);
            DateOfStart = evt.DateOfStart;
            DateOfExpiration = evt.DateOfExpiration;
            Name = evt.JobOrderName;
            Number = evt.JobOrderNumber; 
            IsCompleted = false;
            PurchaseOrderNumber = evt.PurchaseOrderNumber;
            Description = evt.Description;
        }

        public void Extend(DateTime? newDateOfExpiration, decimal value)
        {
            var @event = new TimeAndMaterialJobOrderExtendedEvent(
                this.Id,
                newDateOfExpiration,
                value
            );
            RaiseEvent(@event);
        }

        public void MarkAsCompleted(DateTime dateOfCompletion)
        {
            if (this.DateOfStart > dateOfCompletion)
            {
                throw new ArgumentException("The date of completion cannot precede the date of start.", "dateOfCompletion");
            }
            if (this.IsCompleted)
            {
                throw new InvalidOperationException("The Job Order has already been marked as completed");
            }

            var @event = new TimeAndMaterialJobOrderCompletedEvent(
                this.Id,
                dateOfCompletion
            );
            RaiseEvent(@event);
        }

        public class Factory
        {
            public static TimeAndMaterialJobOrder CreateNewInstance(IJobOrderNumberGenerator jobOrderNumberGenerator, Guid customerId, string customerName, Guid managerId, string managerName, decimal value, string currency, DateTime dateOfStart, DateTime? dateOfExpiration, string name, string purchaseOrderNumber, string description)
            {
                var @event = new TimeAndMaterialJobOrderRegisteredEvent(
                    Guid.NewGuid(),
                    customerId,
                    customerName,
                    managerId,
                    managerName,
                    value,
                    currency,
                    dateOfStart,
                    dateOfExpiration,
                    name,
                    jobOrderNumberGenerator.Generate(),
                    purchaseOrderNumber,
                    description
                    );
                var jobOrder = new TimeAndMaterialJobOrder(); 
                jobOrder.RaiseEvent(@event);
                return jobOrder;
            }
        }
    }
}
