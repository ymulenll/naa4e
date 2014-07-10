using Merp.Accountancy.CommandStack.Commands;
using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Merp.Web.UI.Models.JobOrder;

namespace Merp.Web.UI.WorkerServices
{
    public class JobOrderControllerWorkerServices
    {
        public IBus Bus { get; private set; }

        public JobOrderControllerWorkerServices(IBus bus)
        {
            if(bus==null)
            {
                throw new ArgumentNullException("bus");
            }
            this.Bus = bus;
        }

        public void CreateFixedPriceJobOrder(CreateFixedPriceViewModel model)
        {
            var command = new CreateFixedPriceJobOrderCommand( 
                    model.CustomerCode,
                    model.Price,
                    model.DateOfStart,
                    model.DueDate,
                    model.Name
                );
            Bus.Send(command);
        }

        public void ExtendJobOrder(ExtendViewModel model)
        {

        }
    }
}