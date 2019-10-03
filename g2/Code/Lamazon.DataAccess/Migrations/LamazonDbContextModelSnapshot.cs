﻿// <auto-generated />
using System;
using Lamazon.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lamazon.DataAccess.Migrations
{
    [DbContext(typeof(LamazonDbContext))]
    partial class LamazonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lamazon.Domain.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("DateOfPay");

                    b.Property<int>("OrderId");

                    b.Property<int>("PaymentMethod");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Lamazon.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("Status");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new { Id = 1, DateCreated = new DateTime(2019, 10, 3, 12, 24, 46, 64, DateTimeKind.Utc), Status = 0, UserId = "ba0be5ee-527b-4ebf-b1f8-97bc743f401e" },
                        new { Id = 2, DateCreated = new DateTime(2019, 10, 3, 12, 24, 46, 64, DateTimeKind.Utc), Status = 2, UserId = "ba0be5ee-527b-4ebf-b1f8-97bc743f401e" },
                        new { Id = 3, DateCreated = new DateTime(2019, 10, 3, 12, 24, 46, 64, DateTimeKind.Utc), Status = 1, UserId = "da45d21e-68ac-4708-9405-30cf704d6ffd" }
                    );
                });

            modelBuilder.Entity("Lamazon.Domain.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrdersProducts");

                    b.HasData(
                        new { OrderId = 1, ProductId = 1 },
                        new { OrderId = 1, ProductId = 3 },
                        new { OrderId = 1, ProductId = 5 },
                        new { OrderId = 2, ProductId = 1 },
                        new { OrderId = 2, ProductId = 2 },
                        new { OrderId = 3, ProductId = 4 },
                        new { OrderId = 3, ProductId = 5 },
                        new { OrderId = 3, ProductId = 6 }
                    );
                });

            modelBuilder.Entity("Lamazon.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, Category = 2, Description = "A small tool for removing unwanted hair in unwanted places", Name = "Epilator", Price = 30.0 },
                        new { Id = 2, Category = 2, Description = "For IPhone X", Name = "Headphones", Price = 5.0 },
                        new { Id = 3, Category = 4, Description = "A board game", Name = "Exploding Kittens", Price = 20.0 },
                        new { Id = 4, Category = 1, Description = "A cool drink delivered to your door", Name = "Martini", Price = 10.0 },
                        new { Id = 5, Category = 0, Description = "Meat, Salads, Fries", Name = "Hamburger", Price = 5.0 },
                        new { Id = 6, Category = 3, Description = "by Gregor Hohpe and Bobby Woolf", Name = "Enterprise Integration Patterns", Price = 50.0 }
                    );
                });

            modelBuilder.Entity("Lamazon.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "0d95131c-f812-4692-897c-902690c310fe", AccessFailedCount = 0, ConcurrencyStamp = "781c6997-5d13-4f26-b18c-653d826099e5", Email = "sa@sa.com", EmailConfirmed = true, FullName = "System Admin", LockoutEnabled = false, NormalizedEmail = "SA@SA.COM", NormalizedUserName = "SA", PasswordHash = "AQAAAAEAACcQAAAAEC3YPAoCmTi0+ZZMGGxVsTBhRIGf5NRRnekGDl7Gg1+zEABCMfAHxHO6qeOdaCRSoA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "sa" },
                        new { Id = "a665e25c-c16b-487e-ab6c-105b9c1fafc1", AccessFailedCount = 0, ConcurrencyStamp = "d326c1f0-6ef6-436d-9170-de463589e964", Email = "stojanche.m@mail.com", EmailConfirmed = true, FullName = "Stojanche Mitrevski", LockoutEnabled = false, NormalizedEmail = "STOJANCHE.M@MAIL.COM", NormalizedUserName = "STOJANCHE.M", PasswordHash = "AQAAAAEAACcQAAAAEAgdrBs6cy3LKkZFyVbX/6cFZBB/pzK54nzvgoTzzQkO7j/4O5yrqaSm7+JusITKKA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "stojanche.m" },
                        new { Id = "ba0be5ee-527b-4ebf-b1f8-97bc743f401e", AccessFailedCount = 0, ConcurrencyStamp = "43e18694-13b5-46f4-88fb-4e10b5c4be13", Email = "dejan.blazheski@mail.com", EmailConfirmed = true, FullName = "Dejan Blazheski", LockoutEnabled = false, NormalizedEmail = "DEJAN.BLAZHESKI@MAIL.COM", NormalizedUserName = "DEJAN.BLAZHESKI", PasswordHash = "AQAAAAEAACcQAAAAEElmjTc47W1aupQBSn+NDO4rZtB3e4btZwN2WCRzwdw4cbR3vRisUHByNXXTF+Ajfw==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dejan.blazheski" },
                        new { Id = "da45d21e-68ac-4708-9405-30cf704d6ffd", AccessFailedCount = 0, ConcurrencyStamp = "d5860679-1602-415c-8b9a-8fe5e8d8f62a", Email = "dejan.jovanov@mail.com", EmailConfirmed = true, FullName = "Dejan Jovanov", LockoutEnabled = false, NormalizedEmail = "DEJAN.JOVANOV@MAIL.COM", NormalizedUserName = "DEJAN.JOVANOV", PasswordHash = "AQAAAAEAACcQAAAAEOI8h1EgwhUvLTo8EiOKu13c/oudefMmuuJ+eDIC2xac7wbYy3p+tQvcvXccWxrQ6Q==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dejan.jovanov" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = "5eddfa9a-423c-4313-8ae0-b022b7f0fdab", ConcurrencyStamp = "4108ed98-eaca-4cb4-aad9-e5b2cf762af5", Name = "admin", NormalizedName = "ADMIN" },
                        new { Id = "3f3ddc40-1d77-4c46-acdc-32f813a416a8", ConcurrencyStamp = "16f960e4-4992-4d83-8da5-de8c55b8757d", Name = "supplier", NormalizedName = "SUPPLIER" },
                        new { Id = "bcb45300-9ba5-4bfe-9b17-5e058bf4912e", ConcurrencyStamp = "2f26a309-c3d1-49a2-a226-8bb2ca3e3262", Name = "customer", NormalizedName = "CUSTOMER" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new { UserId = "0d95131c-f812-4692-897c-902690c310fe", RoleId = "5eddfa9a-423c-4313-8ae0-b022b7f0fdab" },
                        new { UserId = "a665e25c-c16b-487e-ab6c-105b9c1fafc1", RoleId = "3f3ddc40-1d77-4c46-acdc-32f813a416a8" },
                        new { UserId = "ba0be5ee-527b-4ebf-b1f8-97bc743f401e", RoleId = "bcb45300-9ba5-4bfe-9b17-5e058bf4912e" },
                        new { UserId = "da45d21e-68ac-4708-9405-30cf704d6ffd", RoleId = "bcb45300-9ba5-4bfe-9b17-5e058bf4912e" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Lamazon.Domain.Models.Invoice", b =>
                {
                    b.HasOne("Lamazon.Domain.Models.Order", "Order")
                        .WithOne()
                        .HasForeignKey("Lamazon.Domain.Models.Invoice", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Lamazon.Domain.Models.Order", b =>
                {
                    b.HasOne("Lamazon.Domain.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Lamazon.Domain.Models.OrderProduct", b =>
                {
                    b.HasOne("Lamazon.Domain.Models.Order", "Order")
                        .WithMany("OrdersProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Lamazon.Domain.Models.Product", "Product")
                        .WithMany("OrdersProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Lamazon.Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Lamazon.Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Lamazon.Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Lamazon.Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
