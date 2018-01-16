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

            ApplicationUser tempUser = await userManager.FindByNameAsync("merchant@merchant.com");

            if (!ctx.Merchants.Any())
            {
                ctx.Merchants.Add(new Merchant
                {
                    CompanyName = "SportsStore",
                    User = tempUser
                });

                ctx.SaveChanges();
            }

            if (!ctx.Categories.Any())
            {
                ctx.Categories.AddRange(
                    new Category { CategoryName = "WaterSports" },
                    new Category { CategoryName = "Soccer" },
                    new Category { CategoryName = "Chess" }
                 );

                ctx.SaveChanges();
            }

            if (!ctx.Products.Any())
            {
                Category WaterSportsCtg = ctx.Categories.SingleOrDefault(c => c.CategoryName == "WaterSports");
                Category SoccerCtg = ctx.Categories.SingleOrDefault(c => c.CategoryName == "Soccer");
                Category ChessCtg = ctx.Categories.SingleOrDefault(c => c.CategoryName == "Chess");

                Merchant SportStore = ctx.Merchants.SingleOrDefault(m => m.CompanyName == "SportStore");

                ctx.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A boat for one person",
                        Category = WaterSportsCtg,                        
                        IsLive = true,                       
                        Price = 275,
                        BoughtPrice = 275 / 3,                        
                        Availability = Availability.Available,
                        Merchant = SportStore                          
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fashionable",
                        Category = WaterSportsCtg,
                        IsLive = true,
                        Price = 48.95m,
                        BoughtPrice = 48.95m / 3,
                        Availability = Availability.Available,
                        Merchant = SportStore
                    },
                    new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = SoccerCtg,
                        IsLive = true,
                        Price = 19.50m,
                        BoughtPrice = 19.50m / 3,
                        Availability = Availability.Available,
                        Merchant = SportStore
                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Description = "Give your playing field a professional touch",
                        Category = SoccerCtg,
                        IsLive = true,
                        Price = 34.95m,
                        BoughtPrice = 34.95m / 3,
                        Availability = Availability.Available,
                        Merchant = SportStore
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = SoccerCtg,
                        IsLive = true,
                        Price = 79500,
                        BoughtPrice = 79500 / 3,
                        Availability = Availability.Available,
                        Merchant = SportStore
                    },
                    new Product
                    {
                        Name = "Thinking Cap",
                        Description = "Improve brain efficiency by 75%",
                        Category = ChessCtg,
                        IsLive = true,
                        Price = 16,
                        BoughtPrice = 16 / 3,
                        Availability = Availability.Available,
                        Merchant = SportStore
                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Category = ChessCtg,
                        IsLive = true,
                        Price = 29.95m,
                        BoughtPrice = 29.95m / 3,
                        Availability = Availability.Available,
                        Merchant = SportStore
                    },
                    new Product
                    {
                        Name = "Human Chess Board",
                        Description = "A fun game for the family",                 
                        Category = ChessCtg,
                        IsLive = true,
                        Price = 75,
                        BoughtPrice = 75/ 3,
                        Availability = Availability.Available,
                        Merchant =SportStore
                    },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = ChessCtg,
                        IsLive = true,
                        Price = 1200,
                        BoughtPrice = 1200 / 3,
                        Availability = Availability.Available,
                        Merchant = SportStore
                    }
                );

                ctx.SaveChanges();
            }
        }

        
    }
}
