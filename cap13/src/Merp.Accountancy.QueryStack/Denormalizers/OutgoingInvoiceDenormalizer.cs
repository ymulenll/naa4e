using Merp.Accountancy.CommandStack.Events;
using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack.Denormalizers
{
    public class OutgoingInvoiceDenormalizer :
        IHandleMessage<OutgoingInvoiceIssuedEvent>
    {
        public void Handle(OutgoingInvoiceIssuedEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
