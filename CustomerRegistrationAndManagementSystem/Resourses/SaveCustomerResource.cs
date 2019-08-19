using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CustomerRegistrationAndManagementSystem.Helpers.CustomValidations;
using Toolbelt.ComponentModel.DataAnnotations.Schema;

namespace CustomerRegistrationAndManagementSystem.Resourses
{
    public class SaveCustomerResource
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]([a-z]+|\.)$", ErrorMessage = "Firstname must be at least 2 symbols long and firs letter Uppercase")]
        [MinLength(2)]
        public string Firstname { get; set; }

        [Required]
        [RegularExpression(@"[A-Z]([a-z]+|\.)", ErrorMessage = "LastName must be at least 2 symbols long and firs letter Uppercase")]
        [MinLength(2)]
        public string Lastname { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required]
        [MinAge(16)]
        public DateTime DateOfBirth { get; set; }

        public string ResidentCountry { get; set; }

        [Required(ErrorMessage = "Must Be Unique")] 
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Personal Number must be 11 digits")]
        [Display(Name = "ID Number")]
        [Index(IsUnique = true)]
        public string PriviteID { get; set; }

        public string Gender { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string RegistrationIP { get; set; }

        public string Language { get; set; }

        [EmailAddress]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Phone]
        [Required]
        [Index(IsUnique = true)]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$",
            ErrorMessage = "Password must contain at least one digit, one " +
            "lowercase and one uppercase symbol and must be at least 8 symbols long")]
        public string Password { get; set; }
        //Address
        public string Country { get; set; }
        public string RegionState { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
    }
}
