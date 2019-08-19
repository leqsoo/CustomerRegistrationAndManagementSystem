using CustomerRegistrationAndManagementSystem.Domain.Models;
using CustomerRegistrationAndManagementSystem.Domain.Repositories;
using CustomerRegistrationAndManagementSystem.Persistence.Contexts;
using CustomerRegistrationAndManagementSystem.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationAndManagementSystem.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task<Customer> FindByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            foreach (var item in customers)
            {
                item.Password = Cryptography.Decrypt(item.Password);
            }
            return customers;
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }
    }
}
