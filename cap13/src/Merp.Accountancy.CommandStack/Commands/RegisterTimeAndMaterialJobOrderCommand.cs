using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merp.Infrastructure;

namespace Merp.Accountancy.CommandStack.Commands
{
    public sealed class RegisterTimeAndMaterialJobOrderCommand : Command
    {
        public Guid CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public decimal? Value { get; private set; }
        public DateTime DateOfStart { get; private set; }
        public DateTime? DateOfExpiration { get; private set; }
        public string JobOrderName { get; private set; }

        public RegisterTimeAndMaterialJobOrderCommand(Guid customerId, string customerName, decimal? value, DateTime dateOfStart, DateTime? dateOfExpiration, string jobOrderName)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Value = value;
            DateOfStart = dateOfStart;
            DateOfExpiration = dateOfExpiration;
            JobOrderName = jobOrderName;
        }
    }
}
