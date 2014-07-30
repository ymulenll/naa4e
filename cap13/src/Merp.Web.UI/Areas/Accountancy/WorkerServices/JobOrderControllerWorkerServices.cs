using Merp.Accountancy.CommandStack.Commands;
using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Merp.Web.UI.Areas.Accountancy.Models.JobOrder;
using Merp.Accountancy.QueryStack;
using Merp.Accountancy.QueryStack.Model;

namespace Merp.Web.UI.Areas.Accountancy.WorkerServices
{
    public class JobOrderControllerWorkerServices
    {
        public IBus Bus { get; private set; }
        public IDatabase Database { get; private set; }
        public IRepository Repository { get; private set; }

        public JobOrderControllerWorkerServices(IBus bus, IDatabase database, IRepository repository)
        {
            if(bus==null)
            {
                throw new ArgumentNullException("bus");
            }
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            this.Bus = bus;
            this.Database = database;
            this.Repository = repository;
        }

        public CreateFixedPriceViewModel GetBlankCreateFixedPriceViewModel()
        {
            var model = new CreateFixedPriceViewModel();
            model.DateOfStart = DateTime.Now;
            return model;
        }

        public void CreateFixedPriceJobOrder(CreateFixedPriceViewModel model)
        {
            var command = new RegisterFixedPriceJobOrderCommand( 
                    model.Customer.OriginalId,
                    model.Customer.Name,
                    model.Price,
                    model.DateOfStart,
                    model.DueDate,
                    model.Name
                );
            Bus.Send(command);
        }

        public CreateTimeAndMaterialViewModel GetBlankCreateTimeAndMaterialViewModel()
        {
            var model = new CreateTimeAndMaterialViewModel();
            model.DateOfStart = DateTime.Now;
            return model;
        }

        public void CreateTimeAndMaterialJobOrder(CreateTimeAndMaterialViewModel model)
        {
            var command = new RegisterTimeAndMaterialJobOrderCommand(
                    model.Customer.OriginalId,
                    model.Customer.Name,
                    model.Value,
                    model.DateOfStart,
                    model.DateOfExpiration,
                    model.Name
                );
            Bus.Send(command);
        }

        public ExtendTimeAndMaterialViewModel GetBlankExtendTimeAndMaterialViewModel(Guid jobOrderId)
        {
            var jobOrder = Repository.GetById<Merp.Accountancy.CommandStack.Model.TimeAndMaterialJobOrder>(jobOrderId);
            var model = new ExtendTimeAndMaterialViewModel();
            model.NewDateOfExpiration = jobOrder.DateOfExpiration;
            model.JobOrderNumber = jobOrder.Number;
            model.JobOrderId = jobOrder.Id;   
            return model;
        }

        public void ExtendTimeAndMaterialJobOrder(ExtendTimeAndMaterialViewModel model)
        {
            //var command = new Extend
        }

        public IEnumerable<IndexViewModel.JobOrder> GetList()
        {
            return (from jo in Database.JobOrders
                   select new IndexViewModel.JobOrder
                   {
                        CustomerId = jo.CustomerId,
                        CustomerName = jo.CustomerName,
                        IsCompleted = jo.IsCompleted,
                        Name = jo.Name,
                        Number = jo.Number,
                        Id = jo.Id,
                        OriginalId = jo.OriginalId
                   }).ToArray();
        }

        public string GetDetailViewModel(Guid jobOrderId)
        {
            if (Database.JobOrders.OfType<FixedPriceJobOrder>().Where(p => p.OriginalId == jobOrderId).Count() == 1)
            {
                return "FixedPrice";
            }
            else if (Database.JobOrders.OfType<TimeAndMaterialJobOrder>().Where(p => p.OriginalId == jobOrderId).Count() == 1)
            {
                return "TimeAndMaterial";
            }
            else
            {
                return "Unknown";
            }
        }

        public FixedPriceJobOrderDetailViewModel GetFixedPriceJobOrderDetailViewModel(Guid jobOrderId)
        {
            var jobOrder = Repository.GetById<Merp.Accountancy.CommandStack.Model.FixedPriceJobOrder>(jobOrderId);

            var model = new FixedPriceJobOrderDetailViewModel();
            model.CustomerName = jobOrder.CustomerName;
            model.DateOfStart = jobOrder.DateOfStart;
            model.JobOrderId = jobOrder.Id;
            model.JobOrderNumber = jobOrder.Number;
            model.Notes = string.Empty;
            model.Price = jobOrder.Price;
            return model;
        }

        public TimeAndMaterialJobOrderDetailViewModel GetTimeAndMaterialJobOrderDetailViewModel(Guid jobOrderId)
        {
            var jobOrder = Repository.GetById<Merp.Accountancy.CommandStack.Model.TimeAndMaterialJobOrder>(jobOrderId);

            var model = new TimeAndMaterialJobOrderDetailViewModel();
            model.CustomerName = jobOrder.CustomerName;
            model.DateOfStart = jobOrder.DateOfStart;
            model.JobOrderId = jobOrder.Id;
            model.JobOrderNumber = jobOrder.Number;
            model.Notes = string.Empty;
            model.Value = jobOrder.Value;
            return model;
        }
    }
}