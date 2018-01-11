using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_WebCoop.Services;

namespace Project_WebCoop.Controllers
{
    [Authorize(Roles="SuperAdmin")]
    public class AdminController : Controller
    {
        IProductRepository _productRepository { get; set; }

        public AdminController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Returns a table with every product
        // available in the database.
        public ViewResult AllProducts()
        {

            return View(_productRepository.Products);
        }

        // Returns a table with all
        // transactions so far. (pagination and filtering)
        public ViewResult ViewSales()
        {
            return View();
        }

        
        public ViewResult DistributeShares()
        {
            return View();
        }
    }
}