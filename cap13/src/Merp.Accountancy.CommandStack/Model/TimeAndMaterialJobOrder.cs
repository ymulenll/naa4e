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
    public class TimeAndMaterialJobOrder : Aggregate
    {
        public decimal? Value { get; private set; }
        public Guid CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public string Number { get; private set; }
        public DateTime DateOfStart { get; private set; }
        public DateTime? DateOfExpiration { get; private set; }
        public DateTime? DateOfCompletion { get; private set; }
        public string Name { get; private set; }
        public bool IsCompleted { get; private set; }

        protected TimeAndMaterialJobOrder()
        {
            
        }

        public decimal CalculateBalance(IEventStore es)
        {
            return CalculateBalance(es, DateTime.Now);
        }

        public decimal CalculateBalance(IEventStore es, DateTime balanceDate)
        {
            if(es==null)
            {
                throw new ArgumentNullException("es");
            }
            throw new NotImplementedException();
        }

        public void Extend(DateTime? newDateOfExpiration, decimal? value)
        {
            this.DateOfExpiration = newDateOfExpiration;
            this.Value = value;

            var @event = new TimeAndMaterialJobOrderExtendedEvent(
                this.Id,
                this.DateOfExpiration,
                this.Value
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
            this.DateOfCompletion = dateOfCompletion;
            this.IsCompleted = true;
            var @event = new TimeAndMaterialJobOrderCompletedEvent(
                this.Id,
                dateOfCompletion
            );
            RaiseEvent(@event);
        }

        public class Factory
        {
            public static TimeAndMaterialJobOrder CreateNewInstance(IJobOrderNumberGenerator jobOrderNumberGenerator, Guid customerId, string customerName, decimal? value, DateTime dateOfStart, DateTime? dateOfExpiration, string name)
            {
                var id = Guid.NewGuid();
                var jobOrder = new TimeAndMaterialJobOrder() 
                {
                    Id = id,
                    CustomerId = customerId,
                    CustomerName = customerName,
                    Value = value,
                    DateOfStart= dateOfStart,
                    DateOfExpiration=dateOfExpiration,
                    Name = name,
                    Number = jobOrderNumberGenerator.Generate(), 
                    IsCompleted = false
                };
                var @event = new TimeAndMaterialJobOrderRegisteredEvent(
                    jobOrder.Id,
                    jobOrder.CustomerId,
                    jobOrder.CustomerName,
                    jobOrder.Value,
                    jobOrder.DateOfStart,
                    jobOrder.DateOfExpiration,
                    jobOrder.Name,
                    jobOrder.Number
                    );
                jobOrder.RaiseEvent(@event);
                return jobOrder;
            }
        }
    }
}
