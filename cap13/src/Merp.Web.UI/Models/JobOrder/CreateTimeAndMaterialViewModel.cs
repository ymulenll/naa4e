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
        public DateTime? DateOfExpiration { get; set; }
        public decimal? Value { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if(DateOfExpiration.HasValue && (DateOfExpiration.Value < DateOfStart))
            {
                errors.Add(new ValidationResult("The expiration date cannot precede the date of start", new string[] { "DateOfStart", "DateOfExpiration" }));
            }
            return errors;
        }
    }
}