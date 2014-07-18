using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merp.Registry.QueryStack.Model;

namespace Merp.Registry.QueryStack
{
    public class RegistryDbContext : DbContext
    {
        public RegistryDbContext()
            : base("MerpReadModel")
        {

        }

        public DbSet<Party> Parties { get; private set; }
    }
}
