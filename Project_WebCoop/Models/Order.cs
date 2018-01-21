using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required]
        public Cart Cart { get; set; }

        [Required]
        public OrderHistory OrderHistory{ get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalCost { get; set; }


    }
}
