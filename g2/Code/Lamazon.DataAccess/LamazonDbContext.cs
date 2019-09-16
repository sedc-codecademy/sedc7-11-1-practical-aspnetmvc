using Lamazon.Domain.Enums;
using Lamazon.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lamazon.DataAccess
{
    public class LamazonDbContext : DbContext
    {
        public LamazonDbContext(DbContextOptions opts) : base(opts) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrdersProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrdersProducts)
                .WithOne(op => op.Order)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrdersProducts)
                .WithOne(op => op.Product)
                .HasForeignKey(op => op.ProductId);

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
                    Email = "sa@sa.com",
                    Password = "sa",
                    Firstname = "System",
                    Lastname = "Admin",
                    Address = "n/a",
                    RoleId = 1
                },
                new User
                {
                    Id = 2,
                    Username = "stojanche.m",
                    Email = "stojanche.m@sedc.com",
                    Password = "123456",
                    Firstname = "Stojanche",
                    Lastname = "Mitrevski",
                    Address = "n/a",
                    RoleId = 2
                },
                new User
                {
                    Id = 3,
                    Username = "dejan.blazheski",
                    Email = "dejan.blazheski@sedc.com",
                    Password = "123456",
                    Firstname = "Dejan",
                    Lastname = "Blazheski",
                    Address = "Fake Street 69",
                    RoleId = 3
                },
                new User
                {
                    Id = 4,
                    Username = "dejan.jovanov",
                    Email = "dejan.jovanov@sedc.com",
                    Password = "123456",
                    Firstname = "Dejan",
                    Lastname = "Jovanov",
                    Address = "Fake Street 13 3/8",
                    RoleId = 3
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    DateCreated = DateTime.UtcNow,
                    Status = StatusType.Init,
                    Paid = false,
                    UserId = 3
                },
                new Order
                {
                    Id = 2,
                    DateCreated = DateTime.UtcNow,
                    Status = StatusType.Confirmed,
                    Paid = false,
                    UserId = 3
                },
                new Order
                {
                    Id = 3,
                    DateCreated = DateTime.UtcNow,
                    Status = StatusType.Processing,
                    Paid = false,
                    UserId = 4
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
                    Description = "For IPhone X",
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

            modelBuilder.Entity<OrderProduct>().HasData(
                //Order 1
                new OrderProduct
                {
                    OrderId = 1,
                    ProductId = 1
                },
                new OrderProduct
                {
                    OrderId = 1,
                    ProductId = 3
                },
                new OrderProduct
                {
                    OrderId = 1,
                    ProductId = 5
                },

                //Order 2
                new OrderProduct
                {
                    OrderId = 2,
                    ProductId = 1
                },
                new OrderProduct
                {
                    OrderId = 2,
                    ProductId = 2
                },

                //Order 3
                new OrderProduct
                {
                    OrderId = 3,
                    ProductId = 4
                },
                new OrderProduct
                {
                    OrderId = 3,
                    ProductId = 5
                },
                new OrderProduct
                {
                    OrderId = 3,
                    ProductId = 6
                }
            );
        }
    }
}
