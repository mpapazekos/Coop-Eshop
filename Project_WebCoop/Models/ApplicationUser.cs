using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Project_WebCoop.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public ApplicationUser(string username) : base(username) { }

        // for client user
        public Cart Cart { get; set; }
        
        // for merchant user
        public WishList WishList { get; set; }

        // If user has merchant role.
        public ICollection<SupplierProduct> SupplierProducts { get; set; } 

        public ICollection<Organization> Organizations { get; set; } 

        public ICollection<Individual> Individuals { get; set; } 

        [NotMapped]
        public Individual GetIndividual => Individuals.SingleOrDefault(indv => indv.User.Equals(this));

        [NotMapped]
        public Organization GetOrganization => Organizations.SingleOrDefault(org => org.User.Equals(this));
  
    }
}
