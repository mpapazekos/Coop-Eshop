using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class CartDetails
    {
        public int CartDetailsID { get; set; }

        public Product Product { get; set; }

        public ApplicationUser User { get; set; }

        public Order Order { get; set; }

        public int Quantity { get; set; }

        public decimal Cost { get; set; }

        public decimal Discount { get; set; }
 
        public CartDetails() { }

        public CartDetails(Product p, int quantity)
        {
            Product = p;
            Quantity = quantity;
        }


        public CartDetails(Product p, int quantity, decimal cost, ApplicationUser user)
        {
            Product = p;
            Quantity = quantity;
            Cost = cost;
            User = user;
        }       
    }
}
