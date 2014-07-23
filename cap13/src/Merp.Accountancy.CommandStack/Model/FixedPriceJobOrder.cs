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
    public class FixedPriceJobOrder : Aggregate
    {
        public decimal Price { get; private set; }
        public Guid CustomerId { get; private set; }
        public string Number { get; private set; }
        public DateTime DateOfStart { get; private set; }
        public DateTime DueDate { get; private set; }
        public string Name { get; private set; }
        public bool IsCompleted { get; private set; }

        protected FixedPriceJobOrder()
        {
            
        }

        public void Extend(DateTime newDueDate, decimal price)
        {
            this.DueDate = newDueDate;
            this.Price = price;

            var @event = new FixedPriceJobOrderExtendedEvent(
                this.Id, 
                this.DueDate,
                this.Price
            );
            RaiseEvent(@event);
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

        public class Factory
        {
            public static FixedPriceJobOrder CreateNewInstance(IJobOrderNumberGenerator jobOrderNumberGenerator, Guid customerId, decimal price, DateTime dateOfStart, DateTime dueDate, string name)
            {
                var id = Guid.NewGuid();
                var jobOrder = new FixedPriceJobOrder() 
                {
                    Id = id,
                    CustomerId = customerId,
                    Price = price,
                    DateOfStart= dateOfStart,
                    DueDate=dueDate,
                    Name = name,
                    Number = jobOrderNumberGenerator.Generate(), 
                    IsCompleted = false
                };
                var @event = new FixedPriceJobOrderRegisteredEvent(
                    jobOrder.Id,
                    jobOrder.CustomerId,
                    jobOrder.Price,
                    jobOrder.DateOfStart,
                    jobOrder.DueDate,
                    jobOrder.Name,
                    jobOrder.Number
                    );
                jobOrder.RaiseEvent(@event);
                return jobOrder;
            }
        }
    }
}
