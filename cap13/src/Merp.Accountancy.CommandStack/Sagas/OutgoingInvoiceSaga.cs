using Merp.Accountancy.CommandStack.Commands;
using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.CommandStack.Sagas
{
    public class OutgoingInvoiceSaga : Saga,
        IAmStartedBy<IssueInvoiceCommand>
    {
        public OutgoingInvoiceSaga(IBus bus, IEventStore eventStore, IRepository repository)
            : base(bus, eventStore, repository)
        {

        }

        public void Handle(IssueInvoiceCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
