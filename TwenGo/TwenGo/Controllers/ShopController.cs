using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Data;
using TwenGo.Models;
using TwenGo.Models.Repository;

namespace 套版測試2.Controllers
{
    public class ShopController : Controller
    {
        private readonly TwenGoContext _context;

        public ShopController(TwenGoContext twenGoContext)
        {
            _context = twenGoContext;
        }
        
        public async Task< IActionResult> Index(string searchString)
        {

            var products = from p in _context.Products
                           select p;
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.Contains(searchString));
            }
            return View(await products.ToListAsync());
        }
        
    }
}
