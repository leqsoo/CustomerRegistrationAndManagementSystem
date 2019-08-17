using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationAndManagementSystem.Resourses
{
    public class SaveCustomerResource
    {
        public int Id { get; set; }
        [Required]
        //[RegularExpression("", ErrorMessage = "Please enter correct Name")]
        [MinLength(2)]
        public string Firstname { get; set; }

        [Required]
        //[RegularExpression(@"[A-Z]([a-z]+|\.)", ErrorMessage = "Please enter correct LastName")]
        [MinLength(2)]
        public string Lastname { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string ResidentCountry { get; set; }

        [Required]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Personal Number must be 11 digits")]
        [Display(Name = "ID Number")]
        public string PriviteID { get; set; }
        public string Gender { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string RegistrationIP { get; set; }
        public string Language { get; set; }

        [EmailAddress]
        [Required]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        //ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Phone]
        [Required]
        public string Mobile { get; set; }

        [Required]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$")]
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
