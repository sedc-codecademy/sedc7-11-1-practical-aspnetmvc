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
                new Product
                {
                    Id = 1,
                    Name = "Epilator",
                    Description = "A small tool for removing unwanted hair in unwanted places",
                    Category = CategoryType.Electronics,
                    Price = 30
                },
                new Product
                {
                    Id = 2,
                    Name = "Headphones",
                    Description = "For IPhone 11Pro",
                    Category = CategoryType.Electronics,
                    Price = 5
                },
                new Product
                {
                    Id = 3,
                    Name = "Exploding Kittens",
                    Description = "A board game",
                    Category = CategoryType.Other,
                    Price = 20
                },
                new Product
                {
                    Id = 4,
                    Name = "Martini",
                    Description = "A cool drink delivered to your door",
                    Category = CategoryType.Drinks,
                    Price = 10
                },
                new Product
                {
                    Id = 5,
                    Name = "Hamburger",
                    Description = "Meat, Salads, Fries",
                    Category = CategoryType.Food,
                    Price = 5
                },
                new Product
                {
                    Id = 6,
                    Name = "Enterprise Integration Patterns",
                    Description = "by Gregor Hohpe and Bobby Woolf",
                    Category = CategoryType.Books,
                    Price = 50
                }
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
                    ProductId = 1
                },
                new ProductOrder
                {
                    Id = 5,
                    OrderId = 2,
                    ProductId = 2
                },

                //Order 3
                new ProductOrder
                {
                    Id = 6,
                    OrderId = 3,
                    ProductId = 4
                },
                new ProductOrder
                {
                    Id = 7,
                    OrderId = 3,
                    ProductId = 5
                },
                new ProductOrder
                {
                    Id = 8,
                    OrderId = 3,
                    ProductId = 6
                }
            );

        }
    }
}
