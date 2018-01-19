using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class WishList
    {
        public int WishListID { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public ICollection<Product> WishItems { get; set; }
    }
}
