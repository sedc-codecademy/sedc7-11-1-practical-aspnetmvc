using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.DataAccess
{
    public class LamazonDbContext : DbContext
    {
        public LamazonDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

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
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "Supplier"
                },
                new Role
                {
                    Id = 3,
                    Name = "Customer"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "sa",
                    Password = "sa",
                    FirstName = "System",
                    LastName = "Admin",
                    Address = "n/a",
                    RoleId = 1
                }, 
                new User
                {
                    Id = 2,
                    Username = "dejan.jovanov",
                    Password = "lozinka",
                    FirstName = "Dejan",
                    LastName = "Jovanov",
                    Address = "Fake Street 13 3/8",
                    RoleId = 2
                },
                new User
                {
                    Id = 3,
                    Username = "dejan.blazheski",
                    Password = "123456",
                    FirstName = "Dejan",
                    LastName = "Blazheski",
                    Address = "Fake Street 69",
                    RoleId = 3
                }                
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Status = StatusType.Init,
                    Paid = false,
                    UserId = 3
                },
                new Order
                {
                    Id = 2,
                    Status = StatusType.Confirmed,
                    Paid = false,
                    UserId = 3
                },
                new Order
                {
                    Id = 3,
                    Status = StatusType.Processing,
                    Paid = false,
                    UserId = 2
                }
            );

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

            modelBuilder.Entity<ProductOrder>().HasData(
                //Order 1
                new ProductOrder
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1
                },
                new ProductOrder
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 3
                },
                new ProductOrder
                {
                    Id = 3,
                    OrderId = 1,
                    ProductId = 5
                },

                //Order 2
                new ProductOrder
                {
                    Id = 4,
                    OrderId = 2,
                    ProductId = 7
                },
                new ProductOrder
                {
                    Id = 5,
                    OrderId = 2,
                    ProductId = 9
                },

                //Order 3
                new ProductOrder
                {
                    Id = 6,
                    OrderId = 3,
                    ProductId = 11
                },
                new ProductOrder
                {
                    Id = 7,
                    OrderId = 3,
                    ProductId = 12
                },
                new ProductOrder
                {
                    Id = 8,
                    OrderId = 3,
                    ProductId = 5
                }
            );

        }
    }
}
