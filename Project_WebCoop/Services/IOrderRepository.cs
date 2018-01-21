using Project_WebCoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Services
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        IQueryable<Cart> Carts { get; }
        IQueryable<CartDetails> CartDetails { get; }
        IQueryable<OrderHistory> OrderHistories { get; }

        

        void SaveOrder(Order order);
        void SaveCart(Cart cart);
        void SaveCartDetails(CartDetails cartDetails);
        void SaveOrderHistory(OrderHistory orderHistory);
        void UpdateCartDetails(CartDetails cartDetails);

        CartDetails GetDetailsById(int detailsId);

        IEnumerable<CartDetails> GetCartDetails(string userId);
        
    }
}
