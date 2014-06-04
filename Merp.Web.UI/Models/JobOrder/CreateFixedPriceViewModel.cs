using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Merp.Web.UI.Models.JobOrder
{
    public class CreateFixedPriceViewModel : IValidatableObject
    {
        [Required]
        public string CustomerCode { get; set; }        
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfStart { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public decimal Price { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if(DueDate < DateOfStart)
            {
                errors.Add(new ValidationResult("The due date cannot precede the date of start", new string[] {"DateOfStart", "DueDate"}));
            }
            return errors;
        }
    }
}