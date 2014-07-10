using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merp.Web.UI.Models.JobOrder
{
    public class ExtendViewModel
    {
        public string JobOrderNumber { get; set; }
        public DateTime ExtendedDueDate { get; set; }
        public decimal Value { get; set; }
    }
}