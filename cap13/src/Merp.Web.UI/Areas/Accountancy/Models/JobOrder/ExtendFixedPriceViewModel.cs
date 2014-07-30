using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Merp.Web.UI.Areas.Accountancy.Models.JobOrder
{
    public class ExtendFixedPriceViewModel : IValidatableObject
    {
        [Required]
        public Guid JobOrderId { get; set; }
        [Required]
        public string JobOrderNumber { get; set; }
        public string JobOrderName { get; set; }
        public string CustomerName { get; set; }
        [Required]
        public DateTime? NewDueDate { get; set; }
        [Required]
        public decimal? Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if(!NewDueDate.HasValue && !Price.HasValue)
            {
                var result = new ValidationResult("Either the new due date or the price has to be specified.", new string[] { "NewDueDate", "Price" });
                results.Add(result);
            }
            return results;
        }
    }
}