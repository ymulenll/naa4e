using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack.Model
{
    public abstract class JobOrder
    {
        public Guid Id { get; private set; }
        public int CustomerId { get; set; }
        public DateTime DateOfStart { get; set; }
        public string Name { get; set; }
    }
}
