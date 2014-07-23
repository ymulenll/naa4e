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
        public string Number { get; private set; }
        public DateTime DateOfStart { get; private set; }
        public DateTime? DateOfExpiration { get; private set; }
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

        public class Factory
        {
            public static TimeAndMaterialJobOrder CreateNewInstance(IJobOrderNumberGenerator jobOrderNumberGenerator, Guid customerId, decimal? value, DateTime dateOfStart, DateTime? dateOfExpiration, string name)
            {
                var id = Guid.NewGuid();
                var jobOrder = new TimeAndMaterialJobOrder() 
                {
                    Id = id,
                    CustomerId = customerId,
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
