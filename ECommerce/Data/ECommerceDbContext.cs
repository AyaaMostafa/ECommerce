using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerce.Data
{
    public class ECommerceDbContext : DbContext
    {
     

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany(p => p.Orders);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product1", Description = "Desc1", Price = 10.99, Stock = 100 },
                new Product { Id = 2, Name = "Product2", Description = "Desc2", Price = 20.99, Stock = 50 },
                new Product { Id = 3, Name = "Product3", Description = "Desc3", Price = 30.99, Stock = 200 }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
