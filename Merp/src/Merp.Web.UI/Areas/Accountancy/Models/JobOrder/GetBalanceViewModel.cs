using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merp.Web.UI.Areas.Accountancy.Models.JobOrder
{
    public class GetBalanceViewModel
    {
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
    }
}