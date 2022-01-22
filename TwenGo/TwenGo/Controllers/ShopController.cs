using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Data;
using TwenGo.Models;
using TwenGo.Models.Repository;

namespace TwenGo.Controllers
{
    public class ShopController : Controller
    {
        private readonly TwenGoContext _context;

        public ShopController(TwenGoContext twenGoContext)
        {
            _context = twenGoContext;
        }
        public async Task<IActionResult> Index(string searchString,int? min,int? max)
        {
            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(x => x.ProductName.Contains(searchString));
            }
            if (min.HasValue && max.HasValue)
            {
                query = query.Where(x => x.Price > min.Value && x.Price <= max.Value);
            }
            ViewBag.searchText = searchString;
            return View(await query.ToListAsync());
        }

        public ActionResult Introduce(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
