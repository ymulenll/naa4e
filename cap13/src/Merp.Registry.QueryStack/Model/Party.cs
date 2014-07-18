using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Registry.QueryStack.Model
{
    public class Party
    {
        public int Id { get; set; }
        public Guid OriginalId { get; set; }
        public string DisplayName { get; set; }
    }
}
