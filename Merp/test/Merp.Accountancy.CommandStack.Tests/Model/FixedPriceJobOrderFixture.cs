using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Memento;
using Merp.Accountancy.CommandStack.Model;
using Merp.Accountancy.CommandStack.Services;
using Merp.Accountancy.CommandStack.Events;
using System.Collections.Generic;
using Memento.Persistence;

namespace Merp.Accountancy.CommandStack.Tests.Model
{
    [TestClass]
    public class FixedPriceJobOrderFixture
    {
        [TestClass]
        public class CalculateBalance_Method
        {
            [TestMethod]
            public void CalculateBalance_With_IncomingInvoicesOnly()
            {
                var generator = new Mock<IJobOrderNumberGenerator>();
                generator
                    .Setup(o => o.Generate())
                    .Returns("101/1989");

                var jobOrderId = Guid.NewGuid();
                var incomingInvoiceId = Guid.NewGuid();
                var eventStore = new Mock<IEventStore>();
                eventStore
                    .Setup(o => o.Find(It.IsAny<Func<IncomingInvoiceLinkedToJobOrderEvent, bool>>()))
                    .Returns(new IncomingInvoiceLinkedToJobOrderEvent[] { new IncomingInvoiceLinkedToJobOrderEvent(incomingInvoiceId, jobOrderId, DateTime.Now, 100) });
                eventStore
                    .Setup(o => o.Find(It.IsAny<Func<IncomingInvoiceRegisteredEvent, bool>>()))
                    .Returns(new IncomingInvoiceRegisteredEvent[] { new IncomingInvoiceRegisteredEvent(incomingInvoiceId, "42", DateTime.Now, 100, 22, 122, "fake", "fake", "", Guid.NewGuid(), "", "", "", "", "", "", "") });

                decimal balance = JobOrder.CalculateBalance(eventStore.Object, jobOrderId);
                decimal expected = -100;
                Assert.AreEqual<decimal>(expected, balance);
            }

            [TestMethod]
            public void CalculateBalance_With_OutgoingInvoicesOnly()
            {
                var generator = new Mock<IJobOrderNumberGenerator>();
                generator
                    .Setup(o => o.Generate())
                    .Returns("101/1989");

                var jobOrderId = Guid.NewGuid();
                var outgoingInvoiceId = Guid.NewGuid();
                var eventStore = new Mock<IEventStore>();
                eventStore
                    .Setup(o => o.Find(It.IsAny<Func<OutgoingInvoiceLinkedToJobOrderEvent, bool>>()))
                    .Returns(new OutgoingInvoiceLinkedToJobOrderEvent[] { new OutgoingInvoiceLinkedToJobOrderEvent(outgoingInvoiceId, jobOrderId, DateTime.Now, 100) });
                eventStore
                    .Setup(o => o.Find(It.IsAny<Func<OutgoingInvoiceIssuedEvent, bool>>()))
                    .Returns(new OutgoingInvoiceIssuedEvent[] { new OutgoingInvoiceIssuedEvent(outgoingInvoiceId, "42", DateTime.Now, 100, 22, 122, "fake", "fake", "", Guid.NewGuid(), "", "", "", "", "", "", "") });

                decimal balance = JobOrder.CalculateBalance(eventStore.Object, jobOrderId);
                decimal expected = 100;
                Assert.AreEqual<decimal>(expected, balance);
            }

            [TestMethod]
            public void CalculateBalance_having_both_Incoming_and_Outgoing_Invoices()
            {
                var generator = new Mock<IJobOrderNumberGenerator>();
                generator
                    .Setup(o => o.Generate())
                    .Returns("101/1989");

                var eventStore = new Mock<IEventStore>();

                var jobOrderId = Guid.NewGuid();
                var outgoingInvoiceId = Guid.NewGuid();
                eventStore
                    .Setup(o => o.Find(It.IsAny<Func<OutgoingInvoiceLinkedToJobOrderEvent, bool>>()))
                    .Returns(new OutgoingInvoiceLinkedToJobOrderEvent[] { new OutgoingInvoiceLinkedToJobOrderEvent(outgoingInvoiceId, jobOrderId, DateTime.Now, 200) });
                eventStore
                    .Setup(o => o.Find(It.IsAny<Func<OutgoingInvoiceIssuedEvent, bool>>()))
                    .Returns(new OutgoingInvoiceIssuedEvent[] { new OutgoingInvoiceIssuedEvent(outgoingInvoiceId, "42", DateTime.Now, 200, 44, 244, "fake", "fake", "", Guid.NewGuid(), "", "", "", "", "", "", "") });

                var incomingInvoiceId = Guid.NewGuid();
                eventStore
                    .Setup(o => o.Find(It.IsAny<Func<IncomingInvoiceLinkedToJobOrderEvent, bool>>()))
                    .Returns(new IncomingInvoiceLinkedToJobOrderEvent[] { new IncomingInvoiceLinkedToJobOrderEvent(incomingInvoiceId, jobOrderId, DateTime.Now, 100) });
                eventStore
                    .Setup(o => o.Find(It.IsAny<Func<IncomingInvoiceRegisteredEvent, bool>>()))
                    .Returns(new IncomingInvoiceRegisteredEvent[] { new IncomingInvoiceRegisteredEvent(incomingInvoiceId, "42", DateTime.Now, 100, 22, 122, "fake", "fake", "", Guid.NewGuid(), "", "", "", "", "", "", "") });
                
                decimal balance = JobOrder.CalculateBalance(eventStore.Object, jobOrderId);
                decimal expected = 100;
                Assert.AreEqual<decimal>(expected, balance);
            }
        }

        [TestClass]
        public class MarkAsCompleted_Method
        {
            //[TestMethod]
            //public void Should_Throw_InvalidOperationException_On()
            //{
            //}
        }

        [TestClass]
        public class AssociateOutgoingInvoice_Method
        {

        }
    }
}
