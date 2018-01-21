using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_WebCoop.Models;
using Project_WebCoop.Models.ProductViewModels;
using Project_WebCoop.Services;

namespace Project_WebCoop.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        private int PageSize = 3;

        public  ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LiveProducts(int productPage = 1)
        {
            return View(new LiveProductsViewModel {

                Products = _repository.Products
                              .Skip((productPage - 1) * PageSize)
                              .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Products.Count()
                }

            } );
        }

        public IActionResult ProductDetails(int productId)
        {

            return View(new ProductDetailsViewModel
            {
                MainProduct = _repository.GetProductById(productId),
                SupplierProducts = _repository.GetSuppliedProducts(productId)
            });
        }

        
    }
}