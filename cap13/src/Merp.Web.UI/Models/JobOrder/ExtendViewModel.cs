using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Merp.Web.UI.Models.JobOrder
{
    public class ExtendViewModel
    {
        [Required]
        public string JobOrderNumber { get; set; }

        [Required]
        public DateTime ExtendedDueDate { get; set; }

        [Required]
        public decimal Value { get; set; }
    }
}