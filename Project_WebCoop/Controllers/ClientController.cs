using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_WebCoop.Services;

namespace Project_WebCoop.Controllers
{
    [Authorize(Roles = "ClientRole")]
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}