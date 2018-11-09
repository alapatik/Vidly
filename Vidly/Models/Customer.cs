using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        [Display(Name= "Date of Birth")]
        [AgeMoreThan18Validation]
        public DateTime? BirthDate{ get; set; }
    }
    public class AgeMoreThan18Validation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if(customer.BirthDate == null)
                return new ValidationResult("Date of birth is required.");
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            if (age < 18)
                return new ValidationResult("Age must be more than or equal to 18.");
            return ValidationResult.Success;
        }
    }
}