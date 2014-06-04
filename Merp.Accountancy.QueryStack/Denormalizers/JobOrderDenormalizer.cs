using Merp.Accountancy.CommandStack.Events;
using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack.Model
{
    public class JobOrderDenormalizer : IHandleMessage<FixedPriceJobOrderCreatedEvent>
    {
        public void Handle(FixedPriceJobOrderCreatedEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
