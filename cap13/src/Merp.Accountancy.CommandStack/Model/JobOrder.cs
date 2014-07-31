using Merp.Accountancy.CommandStack.Events;
using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.CommandStack.Model
{
    public abstract class JobOrder : Aggregate
    {
        public CustomerInfo Customer { get; protected set; }
        public ManagerInfo Manager { get; protected set; }
        public string Name { get; protected set; }
        public string Number { get; protected set; }
        public DateTime DateOfStart { get; protected set; }
        public DateTime? DateOfCompletion { get; protected set; }
        public bool IsCompleted { get; protected set; }
        public string PurchaseOrderNumber { get; protected set; }
        public string Description { get; protected set; }
        public class CustomerInfo
        {
            public Guid Id { get; private set; }
            public string Name { get; private set; }

            public CustomerInfo(Guid id, string name)
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Id cannot be empty", "id");
                }
                if(string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Name cannot be null or empty", "name");
                }
                Id = id;
                Name = name;
            }
        }

        public class ManagerInfo
        {
            public Guid Id { get; private set; }
            public string Name { get; private set; }

            public ManagerInfo(Guid id, string name)
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Id cannot be empty", "id");
                }
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Name cannot be null or empty", "name");
                }
                Id = id;
                Name = name;
            }
        }

        public void AssociateIncomingInvoice(IEventStore eventStore, Guid invoiceId)
        {
            var @event = new IncomingInvoiceAssociatedToJobOrderEvent(invoiceId, this.Id);
            RaiseEvent(@event);
        }

        public void AssociateOutgoingInvoice(IEventStore eventStore, Guid invoiceId)
        {
            var @event = new OutgoingInvoiceAssociatedToJobOrderEvent(invoiceId, this.Id);
            RaiseEvent(@event);
        }
    }
}
