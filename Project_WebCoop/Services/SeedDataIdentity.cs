using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project_WebCoop.Data;
using Project_WebCoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Services
{
    public static class SeedDataIdentity
    {
        public const string AdminName = "admin@admin.com";
        public const string Password = "Data@7";


        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<ApplicationUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .GetRequiredService<RoleManager<IdentityRole>>();

            ApplicationDbContext ctx = app.ApplicationServices
                                          .GetRequiredService<ApplicationDbContext>();


            IdentityRole superAdminRole = await roleManager.FindByNameAsync("SuperAdmin");
            IdentityRole clientRole = await roleManager.FindByNameAsync("ClientRole");
            IdentityRole merchantRole = await roleManager.FindByNameAsync("MerchantRole");

            if (superAdminRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }

            if (clientRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole("ClientRole"));
            }

            if (merchantRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole("MerchantRole"));
            }

            ApplicationUser user = await userManager.FindByNameAsync(AdminName);
            ApplicationUser merchant = await userManager.FindByNameAsync("merchant@merchant.com");
            ApplicationUser client = await userManager.FindByNameAsync("client@client.com");

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = AdminName,
                    Email = "admin@admin.com"
                };


                await userManager.CreateAsync(user, Password);

                await userManager.AddToRoleAsync(user, "SuperAdmin");

            }

            if(merchant == null)
            {
                merchant = new ApplicationUser
                {
                    UserName = "merchant@merchant.com",
                    Email = "merchant@merchant.com"
                };

                await userManager.CreateAsync(merchant, "Data@7");

                await userManager.AddToRoleAsync(merchant, "MerchantRole");
            }

            if(client == null)
            {
                client = new ApplicationUser
                {
                    UserName = "client@client.com",
                    Email = "client@client.com",
                    Cart = new Cart()
                };

                await userManager.CreateAsync(client, "Data@7");

                await userManager.AddToRoleAsync(client, "ClientRole");

            }

            // Add a mockup Organization
            if (!ctx.Organizations.Any())
            {
                ctx.Organizations.Add(new Organization
                {
                    User = merchant,
                    CompanyName = "SportsStore",
                    SSN = "033-76-6079"
                });
            }

            // Populate Category with mockups
            if (!ctx.Categories.Any())
            {
                ctx.Categories.AddRange(
                    new Category { CategoryName = "WaterSports" },
                    new Category { CategoryName = "Soccer" },
                    new Category { CategoryName = "Chess" }
                 );
            }

            Category WaterSportsCtg = ctx.Categories.SingleOrDefault(c => c.CategoryName == "WaterSports");
            Category SoccerCtg = ctx.Categories.SingleOrDefault(c => c.CategoryName == "Soccer");
            Category ChessCtg = ctx.Categories.SingleOrDefault(c => c.CategoryName == "Chess");

            Organization SportStore = ctx.Organizations.SingleOrDefault(m => m.CompanyName == "SportsStore");

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

            if (!ctx.Products.Any())
            {
                  // Populate Products with Mmockups
                ctx.Products.AddRange(MockUpProducts);
                     
            }

            if (!ctx.SupplierProducts.Any())
            {
                // Populate Supplier-Product Table with mockups.

                List<SupplierProduct> MockUpSupplierProducts = new List<SupplierProduct>();
                Random rand = new Random();

                foreach (var item in MockUpProducts)
                {
                    SupplierProduct tempProduct = new SupplierProduct
                    {
                        Supplier = SportStore.User,
                        Product = item,
                        IsLive = true,
                        Availability = "Available"
                    };

                    MockUpSupplierProducts.Add(tempProduct);

                    ctx.BasePrices.Add(new BasePrice
                    {
                        SupplierProduct = tempProduct,
                        BaseUnitPrice = rand.Next(50, 5000),
                        FromDate = DateTime.Now
                    });
                }

                ctx.SupplierProducts.AddRange(MockUpSupplierProducts);
            }

            if (!ctx.ProductCategories.Any())
            {
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

            }

            //ctx.Products.Add(new Product("Product2", "test2"));

            //SupplierProduct TestSP = new SupplierProduct
            //{
            //    Product = new Product("Product3", "test3"),
            //    Supplier = SportStore.User
            //};

            //TestSP.BasePrices.Add(new BasePrice {
            //    Product = TestSP,
            //    BaseUnitPrice = 10,
            //    FromDate = DateTime.Now
            //});

            //ctx.SupplierProducts.Add(TestSP);

            //ApplicationUser User = ctx.SupplierProducts.SingleOrDefault(sp => sp.Product.Name == "Kayak").Supplier;

       
            ctx.SaveChanges();
        }

    }

}
