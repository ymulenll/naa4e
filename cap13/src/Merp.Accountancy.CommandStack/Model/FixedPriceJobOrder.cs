using Merp.Accountancy.CommandStack.Events;
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
        public int CustomerId { get; private set; }
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

        public class Factory
        {
            public static FixedPriceJobOrder CreateNewInstance(int customerId, decimal price, DateTime dateOfStart, DateTime dueDate, string name)
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
                    Number = string.Format("{0}/{1}", id.GetHashCode().ToString(), DateTime.Now.Year), 
                    IsCompleted = false
                };
                return jobOrder;
            }
        }
    }
}
