using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Controllers
{
    public class ShopDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
