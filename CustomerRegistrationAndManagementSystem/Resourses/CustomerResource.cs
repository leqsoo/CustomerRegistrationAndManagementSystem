using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationAndManagementSystem.Resourses
{
    public class CustomerResource
    {
        public int Id { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string ResidentCountry { get; set; }

        public string PriviteID { get; set; }
        public string Gender { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string RegistrationIP { get; set; }
        public string Language { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

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
