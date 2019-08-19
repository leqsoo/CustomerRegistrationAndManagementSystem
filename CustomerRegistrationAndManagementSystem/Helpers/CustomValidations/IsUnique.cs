using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CustomerRegistrationAndManagementSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomerRegistrationAndManagementSystem.Helpers.CustomValidations
{
    public class IsUnique : ValidationAttribute
    {
        public IConfiguration Configuration { get; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CustomerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                var className = "Customers"; /*validationContext.ObjectType.Name;*/
                var propertyName = validationContext.MemberName;
                var parameterName = string.Format("@{0}", propertyName);

                //var result = context.Customers.FromSql("");

#pragma warning disable EF1000 // Possible SQL injection vulnerability.
                var result = context.Database.ExecuteSqlCommand(
                    string.Format("SELECT COUNT(*) FROM {0} WHERE {1}={2}", className, propertyName, parameterName),
                    new System.Data.SqlClient.SqlParameter(parameterName, value)
                    );
#pragma warning restore EF1000 // Possible SQL injection vulnerability.

                if (result < 0)
                {
                    return new ValidationResult(string.Format("The '{0}' already exist", propertyName),
                                new List<string>() { propertyName });
                }

                return null;
            }
        }
    }
}
