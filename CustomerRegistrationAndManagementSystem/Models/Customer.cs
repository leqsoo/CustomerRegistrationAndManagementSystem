using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomerRegistrationAndManagementSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ResidentCountry { get; set; }
        public int PriviteID { get; set; }
        public string Gender { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string RegistrationIP { get; set; }
        public string Language { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public int Mobile { get; set; }

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
