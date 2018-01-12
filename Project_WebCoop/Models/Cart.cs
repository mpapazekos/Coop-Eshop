using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class Cart
    {
        [BindNever]
        public int CartID { get; set; }
   
        public ApplicationUser User { get; set; }

        public ICollection<CartDetails> CartDetails { get; set; }
    }
}
