using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merp.Accountancy.CommandStack;
using Merp.Accountancy.CommandStack.Model;

namespace Merp.Accountancy.CommandStack.RavenDb.Indexes
{
    public class All_JobOrders : AbstractMultiMapIndexCreationTask
    {
        public All_JobOrders()
        {
            AddMap<FixedPriceJobOrder>(jobOrders => from jo in jobOrders 
                                                    select new
                                                    {
                                                        jo.Id,
                                                        jo.Customer,
                                                        jo.Manager,
                                                        jo.Name,
                                                        jo.Number,
                                                        jo.DateOfStart,
                                                        jo.DateOfCompletion,
                                                        jo.IsCompleted,
                                                        jo.PurchaseOrderNumber,
                                                        jo.Description
                                                    });

            AddMap<TimeAndMaterialJobOrder>(jobOrders => from jo in jobOrders
                                                         select new
                                                         {
                                                             jo.Id,
                                                             jo.Customer,
                                                             jo.Manager,
                                                             jo.Name,
                                                             jo.Number,
                                                             jo.DateOfStart,
                                                             jo.DateOfCompletion,
                                                             jo.IsCompleted,
                                                             jo.PurchaseOrderNumber,
                                                             jo.Description
                                                         });
        }
    }
}
