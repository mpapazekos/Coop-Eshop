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

        public IQueryable<Order> Orders => _context.Orders.Include(order => order.OrderItems)
                                                           .Include(order => order.Cart);

        public void DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
