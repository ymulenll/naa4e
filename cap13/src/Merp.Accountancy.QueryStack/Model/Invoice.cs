using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack.Model
{
    public class Invoice
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public Guid? JobOrderId { get; set; }
        public decimal Amount { get; set; }
        public decimal Taxes { get; set; }
        public decimal TotalPrice { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string Description { get; set; }
    }
}
