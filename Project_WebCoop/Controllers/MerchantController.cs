using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project_WebCoop.Controllers
{
    public class MerchantController : Controller
    {
        [Authorize(Roles = "MerchantRole")]
        public IActionResult Index()
        {
            return View();
        }
    }
}