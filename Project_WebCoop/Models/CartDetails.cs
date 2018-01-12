using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class CartDetails
    {
       
        public Product Product { get; set; }

        public Cart Cart { get; set; }

        public int Quantity { get; set; }

        public decimal Cost { get; set; }

        public decimal Discount { get; set; }
       
        public Order Order { get; set; }

    }
}
