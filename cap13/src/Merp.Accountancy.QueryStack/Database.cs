using Merp.Accountancy.QueryStack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack
{
    public class Database : IDatabase
    {
        private MerpContext Context;
        public Database()
        {
            Context = new MerpContext();
            Context.Configuration.AutoDetectChangesEnabled = false;
        }

        public IQueryable<JobOrder> JobOrders
        {
            get
            {
                return Context.JobOrders;
            }
        }
    }
}
