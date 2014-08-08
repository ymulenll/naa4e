using Merp.Accountancy.QueryStack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack
{
    public static class InvoiceExtensions
    {
        public static IQueryable<Invoice> NotAssociatedToAnyJobOrder(this IQueryable<Invoice> invoices)
        {
            return invoices.Where(i => !i.JobOrderId.HasValue);
        }
    }
}
