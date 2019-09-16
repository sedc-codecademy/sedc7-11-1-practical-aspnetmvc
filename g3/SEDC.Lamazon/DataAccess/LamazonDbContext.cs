using Domain.Enumerations;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class LamazonDbContext : IdentityDbContext<User>
    {
        public LamazonDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders{ get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
                .HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);

            builder.Entity<Product>()
                .HasMany(x => x.ProductOrders)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            builder.Entity<Order>()
                .HasMany(x => x.ProductOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            builder.Entity<Order>()
                .HasOne(x => x.Invoice)
                .WithOne(x => x.Order)
                .HasForeignKey<Invoice>(x => x.OrderId);

            //seeding supplier, account and roles
            string supplierId = Guid.NewGuid().ToString();
            string roleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();

            //supplier
            builder.Entity<IdentityRole>().HasData(new User
            {
                Id = supplierId,
                UserName = "supplier",
                NormalizedUserName = "SUPPLIER",
                Email = "supplier@email.com",
                NormalizedEmail = "SUPPLIER@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "P@ssw0rd",
                SecurityStamp = string.Empty
            });

            // set roles
            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = userRoleId,
                Name = "user",
                NormalizedName = "USER"
            });

            // seed products
            builder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Samsung A40", Price = 200, Description = "Very good phone. Bad batery", Category = CategoryType.Electronics },
                new Product() { Id = 2, Name = "SSD 1TB", Price = 400, Description = "Large SSD of high quality", Category = CategoryType.Electronics },
                new Product() { Id = 3, Name = "C# in depth", Price = 40, Description = "C# Book for everyone", Category = CategoryType.Books },
                new Product() { Id = 4, Name = "Clean Code", Price = 60, Description = "Book for clean code", Category = CategoryType.Books },
                new Product() { Id = 5, Name = "Rakija", Price = 20, Description = "Magical Elixir of Power", Category = CategoryType.Drink },
                new Product() { Id = 6, Name = "Sparkling Water", Price = 2, Description = "When you have too much Rakija", Category = CategoryType.Drink },
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
