using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project_WebCoop.Controllers
{
    public class OrderController : Controller
    {
        [Authorize(Roles ="SuperAdmin,ClientRole")]
        public IActionResult Index()
        {
            return View();
        }
    }
}