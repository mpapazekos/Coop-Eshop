using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_WebCoop.Models;

namespace Project_WebCoop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<SupplierProduct> SupplierProducts { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<WishList> WishLists { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        
         
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Create Many to Many Relationship Product-Category
            builder.Entity<ProductCategory>()
                .HasKey(t => new { t.ProductID, t.CategoryID });

            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(ctg => ctg.ProductCategories)
                .HasForeignKey(pc => pc.CategoryID);

            builder.Entity<ProductCategory>()
               .HasOne(pc => pc.Product)
               .WithMany(prd => prd.ProductCategories)
               .HasForeignKey(pc => pc.ProductID);

            // Create Many to Many Relationship: User-Product
            builder.Entity<SupplierProduct>()
                .HasKey(t => new { t.UserID, t.ProductID });

            builder.Entity<SupplierProduct>()
               .HasOne(sp => sp.Product)
               .WithMany(prd => prd.SupplierProducts)
               .HasForeignKey(sp => sp.ProductID);

            builder.Entity<SupplierProduct>()
               .HasOne(sp => sp.Supplier)
               .WithMany(user => user.SupplierProducts)
               .HasForeignKey(sp => sp.UserID);
        }
    }
}
