using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerRegistrationAndManagementSystem.Domain.Repositories;
using CustomerRegistrationAndManagementSystem.Persistence.Contexts;

namespace CustomerRegistrationAndManagementSystem.Persistence.Repositories
{
    public class UnitOfWork : BaseRepository, IUnitOfWork
    {
        public UnitOfWork(AppDbContext context) : base(context)
        {
        }
        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
