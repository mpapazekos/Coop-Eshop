using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Project_WebCoop.Data;
using Project_WebCoop.Models;

namespace Project_WebCoop.Services
{
    public class CartDetailsRepository : ICartDetailsRepository
    {
        private ApplicationDbContext _context;

        public CartDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<CartDetails> CartDetails => _context.CartDetails.Include(ci => ci.Product)
                                                                          .Include(ci => ci.User);


        public void DeleteCartDetails(CartDetails item)
        {           
            _context.Remove(item);
            _context.SaveChanges();
        }

   
        public void StoreCartDetails(CartDetails item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void UpdateCartDetails(CartDetails item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}

