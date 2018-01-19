using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class OrderHistory
    {
        public int OrderHistoryID { get; set; }

        [Required]
        public Order Order { get; set; }

        [Required]
        public IEnumerable<CartDetails> CartItems { get; set; }
    }
}
