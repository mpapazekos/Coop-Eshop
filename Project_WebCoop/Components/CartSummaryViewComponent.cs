using Microsoft.AspNetCore.Mvc;
using Project_WebCoop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//namespace Project_WebCoop.Components
//{
//    public class CartSummaryViewComponent : ViewComponent
//    {
//        private ICartDetailsRepository _repository;

//        public CartSummaryViewComponent(ICartDetailsRepository repository)
//        {
//            _repository = repository;
//        }

//        public IViewComponentResult Invoke(string userId)
//        {     
//            return View(_repository.CartDetails.Where(ci => ci.User.Id == userId));
//        }
//    }
//}
