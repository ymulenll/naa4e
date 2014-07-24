using Merp.Web.UI.Areas.Registry.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Merp.Web.UI.Areas.Accountancy.Models.Invoice
{
    public class IssueViewModel
    {
        public PartyInfo Customer { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Taxes { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public string Description { get; set; }
    }
}