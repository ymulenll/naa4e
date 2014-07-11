using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Merp.Web.UI.Models.JobOrder
{
    public class CreateTimeAndMaterialViewModel : IValidatableObject
    {
        [Required]
        public int CustomerCode { get; set; }        
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfStart { get; set; }
        [Required]
        public DateTime DateOfExpiration { get; set; }
        [Required]
        public decimal HourlyFee { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if(DateOfExpiration < DateOfStart)
            {
                errors.Add(new ValidationResult("The due date cannot precede the date of start", new string[] { "DateOfStart", "DateOfExpiration" }));
            }
            return errors;
        }
    }
}