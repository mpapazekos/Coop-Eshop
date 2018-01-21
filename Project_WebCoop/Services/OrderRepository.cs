using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_WebCoop.Data;
using Project_WebCoop.Models;

namespace Project_WebCoop.Services
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Order> Orders => _context.Orders.Include(order => order.OrderHistory)
                                                          .Include(order => order.Cart);

        public IQueryable<Cart> Carts => _context.Carts.Include(cart => cart.CartHistory)
                                                       .Include(cart => cart.Client);

        public IQueryable<CartDetails> CartDetails => _context.CartDetails.Include(d => d.Cart)
                                                              .Include(d => d.SupplierProduct);

        public IQueryable<OrderHistory> OrderHistories => _context.OrderHistories.Include(oh => oh.CartItems)
                                                                                 .Include(oh => oh.Order);

       

        public void SaveCart(Cart cart)
        {
            _context.AttachRange(cart.CartHistory, cart.Client);
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }

        public void SaveCartDetails(CartDetails cartDetails)
        {
            _context.AttachRange(cartDetails.Cart, cartDetails.SupplierProduct);
            _context.CartDetails.Add(cartDetails);
            _context.SaveChanges();
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Cart, order.OrderHistory);
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void SaveOrderHistory(OrderHistory orderHistory)
        {
            _context.AttachRange(orderHistory.Order, orderHistory.CartItems);
            _context.OrderHistories.Add(orderHistory);
            _context.SaveChanges();
        }


        public void UpdateCartDetails(CartDetails cartDetails)
        {
            _context.CartDetails.Update(cartDetails);
            _context.SaveChanges();
        }

     
        public CartDetails GetDetailsById(int detailsId)
        {
            return CartDetails.SingleOrDefault(cd => cd.CartDetailsID.Equals(detailsId));
        }

        public IEnumerable<CartDetails> GetCartDetails(string userId)
        {
            return CartDetails.Where(cd => cd.Cart.Client.Id.Equals(userId));
        }
    }
}
