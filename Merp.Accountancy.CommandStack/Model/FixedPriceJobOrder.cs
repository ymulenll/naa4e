using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.CommandStack.Model
{
    public class FixedPriceJobOrder
    {
        public Guid Id { get; private set; }
        public decimal Price { get; private set; }
        public int CustomerId { get; private set; }
        public string Number { get; private set; }
        public DateTime DateOfStart { get; private set; }
        public DateTime DueDate { get; private set; }
        
        protected FixedPriceJobOrder()
        {

        }

        public class Factory
        {
            public static FixedPriceJobOrder CreateNewInstance(int customerId, decimal price, DateTime dateOfStart, DateTime dueDate)
            {
                var jobOrder = new FixedPriceJobOrder() 
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customerId,
                    Price = price,
                    DateOfStart= dateOfStart,
                    DueDate=dueDate
                };
                return jobOrder;
            }
        }
    }
}
