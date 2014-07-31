using Merp.Accountancy.CommandStack.Services;
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
        public string Number { get; private set; }
        protected OutgoingInvoice()
        {

        }

        public static class Factory
        {
            public static OutgoingInvoice Issue(IInvoiceNumberGenerator generator, DateTime invoiceDate, decimal amount, decimal taxes, decimal totalPrice, string description, string paymentTerms)
            {
                var invoice = new OutgoingInvoice()
                {
                    Number = generator.Generate()
                };
                return invoice;
            }
        }
    }
}
