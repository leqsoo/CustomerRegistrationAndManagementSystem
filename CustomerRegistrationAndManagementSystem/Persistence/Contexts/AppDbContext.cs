using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerRegistrationAndManagementSystem.Domain.Models;

namespace CustomerRegistrationAndManagementSystem.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasIndex(u => u.Email).IsUnique();
            builder.Entity<Customer>()
                .HasIndex(u => u.PhoneNumber).IsUnique();
            builder.Entity<Customer>()
                .HasIndex(u => u.PriviteID).IsUnique();
        }
    }
}
