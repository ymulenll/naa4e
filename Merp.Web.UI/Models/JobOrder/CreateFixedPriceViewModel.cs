using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merp.Web.UI.Models.JobOrder
{
    public class CreateFixedPriceViewModel
    {
        public string Name { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Price { get; set; }
        public string CustomerCode { get; set; }
    }
}