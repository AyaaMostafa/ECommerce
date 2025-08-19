using ECommerce.Data;
using ECommerce.IRepositories;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerce.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ECommerceDbContext context) : base(context) { }

        public async Task<Order?> GetOrderWithDetailsAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
