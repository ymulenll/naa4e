using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack.Model
{
    public class FixedPriceJobOrder
    {
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public string Number { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DueDate { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
