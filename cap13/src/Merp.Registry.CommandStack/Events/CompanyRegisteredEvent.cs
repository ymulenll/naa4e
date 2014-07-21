using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Registry.CommandStack.Events
{
    public class CompanyRegisteredEvent : DomainEvent
    {
        public Guid PersonId { get; private set; }
        public string CompanyName { get; private set; }
        public string VatIndex { get; private set; }

        public CompanyRegisteredEvent(Guid personId, string companyName, string vatIndex)
        {
            PersonId = personId;
            CompanyName = companyName;
            VatIndex = vatIndex;
        }
    }
}
