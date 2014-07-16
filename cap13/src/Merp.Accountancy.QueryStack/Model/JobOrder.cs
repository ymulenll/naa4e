using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public bool IsCompleted { get; set; }
        public bool IsFixedPrice { get; set; }
        public bool IsTimeAndMaterial { get; set; }
        public string Notes { get; set; }
        public string Number { get; set; }
        public JobOrder()
        {
            IsFixedPrice = false;
            IsTimeAndMaterial = false;
        }
    }
}
