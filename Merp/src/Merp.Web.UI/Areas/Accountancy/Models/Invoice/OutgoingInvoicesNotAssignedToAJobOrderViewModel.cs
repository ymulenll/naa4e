using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merp.Web.UI.Areas.Accountancy.Models.Invoice
{
    public class OutgoingInvoicesNotAssignedToAJobOrderViewModel
    {
        public IEnumerable<Invoice> Invoices { get; set; }

        public class Invoice
        {
            public Guid OriginalId { get; set; }

            public string Number { get; set; }

            public string CustomerName { get; set; }

            public decimal Amount { get; set; }
        }
    }
}