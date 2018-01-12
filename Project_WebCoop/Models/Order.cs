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
        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        public int UserID { get; set; }

        [BindNever]
        public ICollection<CartDetails> Details { get; set; }

        [BindNever]
        public bool IsShipped { get; set; }

        [BindNever]
        public decimal TotalCost { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter an address.")]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required(ErrorMessage ="Please enter a city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a zip code ")]
        public string Zip { get; set; }

        public bool GiftWrap { get; set; }

    }
}
