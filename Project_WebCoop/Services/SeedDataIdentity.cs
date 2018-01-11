using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project_WebCoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Services
{
    public static class SeedDataIdentity
    {
        public const string AdminName = "Admin@admin.com";
        public const string Password = "Data@7";


        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<ApplicationUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .GetRequiredService<RoleManager<IdentityRole>>();

            ApplicationUser user = await userManager.FindByNameAsync(AdminName);
            ApplicationUser merchant = await userManager.FindByNameAsync("merchant@merchant.com");


            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = AdminName,
                    Email = "Admin@admin.com"
                };


                await userManager.CreateAsync(user, Password);
            
            }

            //await userManager.AddToRoleAsync(user, "SuperAdmin");

            IdentityRole superAdminRole = await roleManager.FindByNameAsync("SuperAdmin");
            IdentityRole clientRole = await roleManager.FindByNameAsync("ClientRole");
            IdentityRole merchantRole = await roleManager.FindByNameAsync("MerchantRole");

            if (superAdminRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));

                await userManager.AddToRoleAsync(user, "SuperAdmin");
            }

            if (clientRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole("ClientRole"));
            }

            if (merchantRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole("MerchantRole"));
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
            
        }
    }
}
