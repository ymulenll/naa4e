using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memento;
using Memento.Domain;
using Merp.Registry.CommandStack.Events;

namespace Merp.Registry.CommandStack.Model
{
    public class Company : Party,
        IApplyEvent<CompanyRegisteredEvent>
    {
        public string CompanyName { get; private set; }
        protected Company()
        {

        }

        public void ApplyEvent(CompanyRegisteredEvent evt)
        {
            this.Id = evt.CompanyId;
            this.CompanyName = evt.CompanyName;
            this.VatIndex = evt.VatIndex;
        }

        public static class Factory
        {
            public static Company CreateNewEntry(string companyName, string vatIndex)
            {
                var p = new Company();
                var e = new CompanyRegisteredEvent(Guid.NewGuid(), companyName, vatIndex);
                p.RaiseEvent(e);
                return p;
            }
        }
    }
}
