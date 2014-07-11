using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merp.Infrastructure;

namespace Merp.Accountancy.CommandStack.Commands
{
    public sealed class CreateTimeAndMaterialJobOrderCommand : Command
    {
        public int CustomerId { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DateOfStart { get; private set; }
        public DateTime DueDate { get; private set; }
        public string JobOrderName { get; private set; }

        public CreateTimeAndMaterialJobOrderCommand(int customerId, decimal price, DateTime dateOfStart, DateTime dueDate, string jobOrderName)
        {
            CustomerId = customerId;
            Price = price;
            DateOfStart = dateOfStart;
            DueDate = dueDate;
            JobOrderName = jobOrderName;
        }
    }
}
