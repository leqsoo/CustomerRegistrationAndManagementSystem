using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerRegistrationAndManagementSystem.Domain.Models;

namespace CustomerRegistrationAndManagementSystem.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task AddAsync(Customer customer);
        Task<Customer> FindByIdAsync(int id);
        void Update(Customer customer);
    }
}
