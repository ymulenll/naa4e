using Merp.Accountancy.QueryStack.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack
{
    class MerpContext : DbContext
    {
        public MerpContext()
            : base("MerpReadModel")
        {

        }

        public DbSet<JobOrder> JobOrders { get; set; }
        public DbSet<FixedPriceJobOrder> FixedPriceJobOrders { get; set; }
    }
}
