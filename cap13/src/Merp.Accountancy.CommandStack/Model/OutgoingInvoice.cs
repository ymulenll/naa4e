using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.CommandStack.Model
{
    public class OutgoingInvoice : Aggregate
    {
        protected OutgoingInvoice()
        {

        }

        public static class Factory
        {
            public static OutgoingInvoice Issue(string invoiceNumber, DateTime invoiceDate, decimal amount, decimal taxes, decimal totalPrice, string description, string paymentTerms)
            {
                var invoice = new OutgoingInvoice()
                {

                };
                return invoice;
            }
        }
    }
}
