using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack.Model
{
    public abstract class JobOrder
    {
        public int Id { get; set; }
        public Guid OriginalId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public string Name { get; set; }
    }
}
