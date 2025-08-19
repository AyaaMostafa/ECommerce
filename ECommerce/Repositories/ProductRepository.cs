using ECommerce.Data;
using ECommerce.IRepositories;
using ECommerce.Models;
using System;

namespace ECommerce.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext context) : base(context) { }
    }
}
