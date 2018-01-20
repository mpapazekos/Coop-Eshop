﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Project_WebCoop.Data;
using System;

namespace Project_WebCoop.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180119150442_TestingModels")]
    partial class TestingModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("Project_WebCoop.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

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

                    b.Property<int?>("WishListID");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("WishListID")
                        .IsUnique()
                        .HasFilter("[WishListID] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Project_WebCoop.Models.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientId")
                        .IsRequired();

                    b.HasKey("CartID");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Project_WebCoop.Models.CartDetails", b =>
                {
                    b.Property<int>("CartDetailsID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CartID");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateRemoved");

                    b.Property<int?>("OrderHistoryID");

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("CartDetailsID");

                    b.HasIndex("CartID");

                    b.HasIndex("OrderHistoryID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("Project_WebCoop.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("ImagePath");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Project_WebCoop.Models.Individual", b =>
                {
                    b.Property<int>("IndividualID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("IndividualID");

                    b.HasIndex("UserId");

                    b.ToTable("Individuals");
                });

            modelBuilder.Entity("Project_WebCoop.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CartID");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderHistoryID");

                    b.HasKey("OrderID");

                    b.HasIndex("CartID");

                    b.HasIndex("OrderHistoryID")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Project_WebCoop.Models.OrderHistory", b =>
                {
                    b.Property<int>("OrderHistoryID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("OrderHistoryID");

                    b.ToTable("OrderHistories");
                });

            modelBuilder.Entity("Project_WebCoop.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<string>("SSN")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("OrganizationID");

                    b.HasIndex("UserId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Project_WebCoop.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("WishListID");

                    b.HasKey("ProductID");

                    b.HasIndex("WishListID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Project_WebCoop.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductID");

                    b.Property<int>("CategoryID");

                    b.Property<DateTime>("FromDate");

                    b.Property<DateTime>("ThroughDate");

                    b.HasKey("ProductID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Project_WebCoop.Models.SupplierProduct", b =>
                {
                    b.Property<string>("UserID");

                    b.Property<int>("ProductID");

                    b.Property<string>("Availability");

                    b.Property<decimal>("BasePrice");

                    b.Property<bool>("IsLive");

                    b.Property<decimal>("SalePrice");

                    b.HasKey("UserID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("SupplierProduct");
                });

            modelBuilder.Entity("Project_WebCoop.Models.WishList", b =>
                {
                    b.Property<int>("WishListID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("WishListID");

                    b.ToTable("WishLists");
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
                    b.HasOne("Project_WebCoop.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Project_WebCoop.Models.ApplicationUser")
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

                    b.HasOne("Project_WebCoop.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Project_WebCoop.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_WebCoop.Models.ApplicationUser", b =>
                {
                    b.HasOne("Project_WebCoop.Models.WishList", "WishList")
                        .WithOne("User")
                        .HasForeignKey("Project_WebCoop.Models.ApplicationUser", "WishListID");
                });

            modelBuilder.Entity("Project_WebCoop.Models.Cart", b =>
                {
                    b.HasOne("Project_WebCoop.Models.ApplicationUser", "Client")
                        .WithOne("Cart")
                        .HasForeignKey("Project_WebCoop.Models.Cart", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_WebCoop.Models.CartDetails", b =>
                {
                    b.HasOne("Project_WebCoop.Models.Cart", "Cart")
                        .WithMany("CartHistory")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project_WebCoop.Models.OrderHistory")
                        .WithMany("CartItems")
                        .HasForeignKey("OrderHistoryID");

                    b.HasOne("Project_WebCoop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_WebCoop.Models.Individual", b =>
                {
                    b.HasOne("Project_WebCoop.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_WebCoop.Models.Order", b =>
                {
                    b.HasOne("Project_WebCoop.Models.Cart", "Cart")
                        .WithMany("Orders")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project_WebCoop.Models.OrderHistory", "OrderHistory")
                        .WithOne("Order")
                        .HasForeignKey("Project_WebCoop.Models.Order", "OrderHistoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_WebCoop.Models.Organization", b =>
                {
                    b.HasOne("Project_WebCoop.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_WebCoop.Models.Product", b =>
                {
                    b.HasOne("Project_WebCoop.Models.WishList")
                        .WithMany("WishItems")
                        .HasForeignKey("WishListID");
                });

            modelBuilder.Entity("Project_WebCoop.Models.ProductCategory", b =>
                {
                    b.HasOne("Project_WebCoop.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project_WebCoop.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_WebCoop.Models.SupplierProduct", b =>
                {
                    b.HasOne("Project_WebCoop.Models.Product", "Product")
                        .WithMany("SupplierProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project_WebCoop.Models.ApplicationUser", "Supplier")
                        .WithMany("SupplierProducts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}