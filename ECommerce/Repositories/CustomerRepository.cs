using ECommerce.Data;
using ECommerce.IRepositories;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerce.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ECommerceDbContext context) : base(context) { }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

    }
}
