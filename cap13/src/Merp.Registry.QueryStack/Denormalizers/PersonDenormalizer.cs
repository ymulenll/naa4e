using Merp.Infrastructure;
using Merp.Registry.CommandStack.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Registry.QueryStack.Denormalizers
{
    public class PersonDenormalizer : IHandleMessage<PersonRegisteredEvent>
    {
        public void Handle(PersonRegisteredEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
