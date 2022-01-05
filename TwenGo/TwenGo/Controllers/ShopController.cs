using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Data;
using TwenGo.Models;

namespace 套版測試2.Controllers
{
    public class ShopController : Controller
    {
        private readonly TwenGoContext _context;

        public ShopController(TwenGoContext twenGoContext)
        {
            _context = twenGoContext;
        }
        
        public async Task< IActionResult> Index(string searching)
        {
            var products = from p in _context.Product
                           select p;
            if (!string.IsNullOrEmpty(searching))
            {
                products = products.Where(s => s.ProductName.Contains(searching));
            }
            return View(await products.ToListAsync());
        }
        
    }
}
