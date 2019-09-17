using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.DataAccess
{
    public class LamazonDbContext : IdentityDbContext<User>
    {
        public LamazonDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });


            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.ProductOrders)
                .WithOne(po => po.Order)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductOrders)
                .WithOne(po => po.Product)
                .HasForeignKey(po => po.ProductId);


            //Data Seed
            

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Samsung A40", Price = 200, Description = "Very good phone. Bad batery", Category = CategoryType.Electronics },
                new Product() { Id = 2, Name = "SSD 1TB", Price = 400, Description = "Large SSD of high quality", Category = CategoryType.Electronics },
                new Product() { Id = 3, Name = "C# in depth", Price = 40, Description = "C# Book for everyone", Category = CategoryType.Books },
                new Product() { Id = 4, Name = "Clean Code", Price = 60, Description = "Book for clean code", Category = CategoryType.Books },
                new Product() { Id = 5, Name = "Rakija", Price = 20, Description = "Magical Elixir of Power", Category = CategoryType.Drinks },
                new Product() { Id = 6, Name = "Sparkling Water", Price = 2, Description = "When you have too much Rakija", Category = CategoryType.Drinks },
                new Product() { Id = 7, Name = "Meze", Price = 15, Description = "All in one pack of appetizers", Category = CategoryType.Food },
                new Product() { Id = 8, Name = "Stew in a can", Price = 8, Description = "Stew for good morning", Category = CategoryType.Food },
                new Product() { Id = 9, Name = "Glasses set", Price = 10, Description = "Set of 6 glasses", Category = CategoryType.Other },
                new Product() { Id = 10, Name = "Plastic knives and forks", Price = 4, Description = "Set of 20 plastic knives and forks", Category = CategoryType.Other },
                new Product() { Id = 11, Name = "Ice", Price = 3, Description = "A bag of ice", Category = CategoryType.Other },
                new Product() { Id = 12, Name = "Plastic plates", Price = 5, Description = "Plates for the whole family", Category = CategoryType.Other }
            );
        }
    }
}
