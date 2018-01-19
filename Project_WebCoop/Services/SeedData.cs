using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project_WebCoop.Data;
using Project_WebCoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Services
{
    public static class SeedData
    {

        public async static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext ctx = app.ApplicationServices
                                          .GetRequiredService<ApplicationDbContext>();

            UserManager<ApplicationUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<ApplicationUser>>();

            //ctx.Database.Migrate();

            ApplicationUser merchant = await userManager.FindByNameAsync("merchant@merchant.com");

            // Add a mockup Organization
            if (!ctx.Organizations.Any())
            {
                ctx.Organizations.Add(new Organization
                {
                    User = merchant,
                    CompanyName = "SportsStore",
                    SSN = "033-76-6079"
                });

                ctx.SaveChanges();
            }

            // Populate Category with mockups
            if (!ctx.Categories.Any())
            {
                ctx.Categories.AddRange(
                    new Category { CategoryName = "WaterSports" },
                    new Category { CategoryName = "Soccer" },
                    new Category { CategoryName = "Chess" }
                 );

                ctx.SaveChanges();
            }

            Category WaterSportsCtg = ctx.Categories.SingleOrDefault(c => c.CategoryName == "WaterSports");
            Category SoccerCtg = ctx.Categories.SingleOrDefault(c => c.CategoryName == "Soccer");
            Category ChessCtg = ctx.Categories.SingleOrDefault(c => c.CategoryName == "Chess");

            Organization SportStore = ctx.Organizations.SingleOrDefault(m => m.CompanyName == "SportStore");



            if (!ctx.Products.Any())
            {
                // Create Mockup Products
                Product Kayak = new Product("Kayak", "A boat for one person");
                Product LifeJacket = new Product("Lifejacket", "Protective and fashionable");
                Product SoccerBall = new Product("Soccer Ball", "FIFA-approved size and weight");
                Product CornerFlags = new Product("Corner Flags", "Give your playing field a professional touch");
                Product Stadium = new Product("Stadium", "Flat-packed 35,000-seat stadium");
                Product ThinkingCap = new Product("Thinking Cap", "Improve brain efficiency by 75%");
                Product UnsteadyChair = new Product("Unsteady Chair", "Secretly give your opponent a disadvantage");
                Product HumanChessBoard = new Product("Human Chess Board", "A fun game for the family");
                Product BlingBling = new Product("Bling-Bling King", "Gold-plated, diamond-studded King");

                List<Product> MockUpProducts = new List<Product> {
                   Kayak,
                   LifeJacket,
                   SoccerBall,
                   CornerFlags,
                   Stadium,
                   ThinkingCap,
                   UnsteadyChair,
                   HumanChessBoard,
                   BlingBling
                };

                // Populate Products with Mmockups
                ctx.Products.AddRange(MockUpProducts);

                // Populate Product-Category Table
                ctx.ProductCategories.AddRange(
                    new ProductCategory
                    {
                        Product = Kayak,
                        Category = WaterSportsCtg
                    },
                    new ProductCategory
                    {
                        Product = LifeJacket,
                        Category = WaterSportsCtg
                    },
                    new ProductCategory
                    {
                        Product = SoccerBall,
                        Category = SoccerCtg
                    },
                    new ProductCategory
                    {
                        Product = CornerFlags,
                        Category = SoccerCtg
                    },
                    new ProductCategory
                    {
                        Product = Stadium,
                        Category = SoccerCtg
                    },
                    new ProductCategory
                    {
                        Product = ThinkingCap,
                        Category = ChessCtg
                    },
                    new ProductCategory
                    {
                        Product = UnsteadyChair,
                        Category = ChessCtg
                    },
                    new ProductCategory
                    {
                        Product = HumanChessBoard,
                        Category = ChessCtg
                    },
                    new ProductCategory
                    {
                        Product = BlingBling,
                        Category = ChessCtg
                    }
                );

                // Populate Supplier-Product Table with mockups.

                List<SupplierProduct> MockUpSupplierProducts = new List<SupplierProduct>();
                Random rand = new Random();

                foreach (var item in MockUpProducts)
                {
                    MockUpSupplierProducts.Add(new SupplierProduct
                    {
                        Supplier = SportStore.User,
                        Product = item,
                        IsLive = true,
                        BasePrice = rand.Next(30, 2500),
                        Availability = "Available"
                    });
                }

                ctx.SupplierProducts.AddRange(MockUpSupplierProducts);

                ctx.SaveChanges();
            }

        }


    }
}
