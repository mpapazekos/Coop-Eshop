using Project_WebCoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Services
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Name = "Adidas Socks", Price = 25},
            new Product {Name = "Nike Shoes", Price = 180},
            new Product {Name = "Basket ball", Price = 35}

        }.AsQueryable();      
    }
}
