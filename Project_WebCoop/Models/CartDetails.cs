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

        public Cart Cart { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
 
        public DateTime DateAdded { get; set; }

        public DateTime DateRemoved { get; set; }


        public CartDetails() { }

        public CartDetails(Product p, int quantity)
        {
            Product = p;
            Quantity = quantity;
        }   
    }
}
