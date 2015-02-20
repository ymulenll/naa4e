using Merp.Registry.CommandStack.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Registry.CommandStack.Model
{
    public class Person : Party
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        
        protected Person()
        {

        }

        public void Apply(PersonRegisteredEvent evt)
        {
            this.Id = evt.PersonId;
            this.FirstName = evt.FirstName;
            this.LastName = evt.LastName;
        }

        public static class Factory
        {
            public static Person CreateNewEntry(string firstName, string lastName, DateTime? dateOfBirth)
            {
                var e = new PersonRegisteredEvent(Guid.NewGuid(), firstName, lastName);
                var p = new Person();
                p.RaiseEvent(e);
                return p;
            }
        }
    }
}
