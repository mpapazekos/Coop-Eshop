using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_WebCoop.Extensions;
using Project_WebCoop.Models;
using Project_WebCoop.Models.ProductViewModels;
using Project_WebCoop.Services;

namespace Project_WebCoop.Controllers
{
    public class CartController : Controller
    {
        private ICartDetailsRepository _cartRepository;
        private IProductRepository _productRepository;
        private UserManager<ApplicationUser> _userManager;

        public CartController(UserManager<ApplicationUser> userManager,
            ICartDetailsRepository cartRepo,
            IProductRepository productRepo)
        {
            _cartRepository = cartRepo;
            _productRepository = productRepo;
            _userManager = userManager;
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(User);
        }

        public async Task<IActionResult> CartDetails()
        {
            var user = await GetCurrentUser();


            return View(_cartRepository.CartDetails.Where(cd => cd.User.Id == user.Id));
        }

        public async Task<IActionResult> AddToCart(int productId)
        {
            // Get user.
            var user = await GetCurrentUser();

            // Get cart item if in user's cart.
            CartDetails cartItem = _cartRepository.CartDetails
                .SingleOrDefault(item => item.User.Equals(user) && item.Product.ProductID == productId);

            // if item not in cart, add new item.
            if(cartItem == null)
            {
                var product = _productRepository.Products.SingleOrDefault(p => p.ProductID == productId);

                _cartRepository.StoreCartDetails(new CartDetails(product, 1, product.Price, user));
            }
            else
            {
                cartItem.Quantity++;
                cartItem.Cost += cartItem.Cost;
                _cartRepository.UpdateCartDetails(cartItem);
            }

             return Json(cartItem.Product.Name);
        }

        public async Task<IActionResult> RemoveFromCart(int detailsId)
        {
            // Get user.
            var user = await GetCurrentUser();

            // Get CartDetails of user.
            CartDetails cartItem = _cartRepository.CartDetails
                .SingleOrDefault(item => item.User.Equals(user) && item.CartDetailsID == detailsId);

           

            if (cartItem.Quantity == 1)
            {
                // Remove item from cartDetails
                _cartRepository.DeleteCartDetails(cartItem);
            }
            else
            {
                cartItem.Quantity--;
                cartItem.Cost -= cartItem.Cost;
                _cartRepository.UpdateCartDetails(cartItem);
            }

            var results = new CartDetailsRemoveViewModel
            {
                ItemCount = cartItem.Quantity,
                DeleteId = detailsId
            };

            return Json(results);
        }

    }
}