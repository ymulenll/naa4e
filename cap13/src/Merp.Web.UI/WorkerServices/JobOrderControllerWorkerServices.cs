using Merp.Accountancy.CommandStack.Commands;
using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Merp.Web.UI.Models.JobOrder;
using Merp.Accountancy.QueryStack;

namespace Merp.Web.UI.WorkerServices
{
    public class JobOrderControllerWorkerServices
    {
        public IBus Bus { get; private set; }
        public IDatabase Database { get; set; }

        public JobOrderControllerWorkerServices(IBus bus, IDatabase database)
        {
            if(bus==null)
            {
                throw new ArgumentNullException("bus");
            }
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            this.Bus = bus;
            this.Database = database;
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

        public void CreateTimeAndMaterialJobOrder(CreateTimeAndMaterialViewModel model)
        {
            var command = new CreateTimeAndMaterialJobOrderCommand(
                    model.CustomerCode,
                    model.Value,
                    model.DateOfStart,
                    model.DateOfExpiration,
                    model.Name
                );
            Bus.Send(command);
        }

        public void ExtendJobOrder(ExtendTimeAndMaterialViewModel model)
        {

        }

        public IEnumerable<IndexViewModel.JobOrder> GetList()
        {
            return (from jo in Database.JobOrders
                   select new IndexViewModel.JobOrder
                   {
                        CustomerId = jo.CustomerId,
                        IsCompleted = jo.IsCompleted,
                        Name = jo.Name,
                        Number = jo.Number,
                        Id = jo.Id,
                        OriginalId = jo.OriginalId
                   }).ToArray();
        }
    }
}