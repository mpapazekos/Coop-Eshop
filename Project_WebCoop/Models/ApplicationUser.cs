using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Project_WebCoop.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() {}

        public ApplicationUser(string username) : base(username) { }

        public ICollection<Order> Orders { get; set; }
        public ICollection<CartDetails> CartDetails { get; set; }
        public WishList WishList { get; set; }
    }
}
