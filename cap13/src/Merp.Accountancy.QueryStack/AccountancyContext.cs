using Merp.Accountancy.QueryStack.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack
{
    class AccountancyContext : DbContext
    {
        public AccountancyContext()
            : base("MerpReadModel")
        {

        }

        public DbSet<JobOrder> JobOrders { get; set; }

        public DbSet<Invoice> OutgoingInvoices { get; set; }
    }
}
