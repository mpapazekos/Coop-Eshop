using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_WebCoop.Models;
using Project_WebCoop.Models.ProductViewModels;
using Project_WebCoop.Services;

namespace Project_WebCoop.Controllers
{
    public class ProductController : Controller
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private UserManager<ApplicationUser> _userManager;

        private int PageSize = 3;

        public  ProductController(UserManager<ApplicationUser> userManager,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LiveProducts(int productPage = 1)
        {
            return View(new LiveProductsViewModel {

                Products = _productRepository.Products
                              .Skip((productPage - 1) * PageSize)
                              .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _productRepository.Products.Count()
                }

            } );
        }

        public async Task<IActionResult> ProductDetails(int productId)
        {
            int cartId = await GetUserCart();

            return View(new ProductDetailsViewModel
            {
                MainProduct = _productRepository.GetProductById(productId),
                SupplierProducts = _productRepository.GetSuppliedProducts(productId),
                CartId = cartId
            });
        }

        private async Task<int> GetUserCart()
        {
            var user = await _userManager.GetUserAsync(User);

            return _orderRepository.Carts.SingleOrDefault(c => c.Client.Id.Equals(user.Id)).CartID;
        }
        
    }
}