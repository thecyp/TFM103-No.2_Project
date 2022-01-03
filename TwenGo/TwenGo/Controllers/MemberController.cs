using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Models;
using TwenGo.ViewModels;

namespace TwenGo.Controllers
{
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;

        
        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }

       

        public IActionResult CustomerRegister()
        {
            
            return View();
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomerRegister(CustomerViewModel customer)
        {
            //TwenGoContext  AAA= new TwenGoContext();
            
           return RedirectToAction(nameof(Index));
        }

        public IActionResult SupplierRegister()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SupplierRegister(int id)
        {
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
