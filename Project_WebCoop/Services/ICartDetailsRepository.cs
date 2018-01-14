using Project_WebCoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Services
{
    public interface ICartDetailsRepository
    {
        IQueryable<CartDetails> CartDetails { get; }

        void StoreCartDetails(CartDetails item);
        void UpdateCartDetails(CartDetails item);
        void DeleteCartDetails(CartDetails item);
       
    }
}
