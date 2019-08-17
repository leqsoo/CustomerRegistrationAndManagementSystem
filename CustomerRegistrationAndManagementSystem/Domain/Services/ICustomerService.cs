using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerRegistrationAndManagementSystem.Domain.Models;
using CustomerRegistrationAndManagementSystem.Domain.Services.Communication;

namespace CustomerRegistrationAndManagementSystem.Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task<SaveCustomerResponse> SaveAsync(Customer customer);
        Task<SaveCustomerResponse> UpdateAsync(int id, Customer customer);
    }
}
