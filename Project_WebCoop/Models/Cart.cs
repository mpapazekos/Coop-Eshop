using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class Cart
    {
        public int CartID { get; set; }

        [Required]
        public ApplicationUser Client { get; set; }

        public ICollection<CartDetails> CartHistory { get; set; } = new List<CartDetails>();

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        [NotMapped]
        public IEnumerable<CartDetails> CurrentCart => CartHistory.Where(ci => ci.DateRemoved != null);

        [NotMapped]
        public IEnumerable<CartDetails> OldCart => CartHistory.Where(ci => ci.DateRemoved == null);


        public void RemoveItems()
        {
            foreach(var item in CurrentCart)
            {
                item.DateRemoved = DateTime.Now;
            }
        }  
    }


    //public Checkout(int cartid)
    //{
    //    Cart cart = _cartrepository.Carts.SingelOrDefault(c => c.Id == cartId);


    //    Order order = new Order
    //    {
    //        Cart = cart,
    //        OrderDate = DateTime.Now,
    //        OrderHistory = new OrderHistory { CartItems = cart.CartItems}

    //    };

    //    _orderReporitory.Orders.Add(order);


    //}



}
