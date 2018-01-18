using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class OrderHistory
    {
        public ICollection<Order> OrdersHistory { get; set; }

        public IEnumerable<CartDetails> CartItems { get; set; }
    }
}
