using CustomerRegistrationAndManagementSystem.Resourses;
using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerRegistrationAndManagementSystem.Helpers.CustomValidations
{
    public class MinAge : ValidationAttribute
    {
        private readonly int _minAge;
        public MinAge(int minAge)
        {
            _minAge = minAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (SaveCustomerResource)validationContext.ObjectInstance;

            if (customer.DateOfBirth == null)
                return new ValidationResult("BirthDate is required!");

            var age = DateTime.Today.Year - customer.DateOfBirth.Year;

            if (customer.DateOfBirth.Date > DateTime.Today.AddYears(-age))
                age--;

            return (age >= _minAge)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 16 yars old!");
        }
    }
}
