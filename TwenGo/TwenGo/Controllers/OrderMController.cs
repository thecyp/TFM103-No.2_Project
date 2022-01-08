using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Models;
using TwenGo.Models.Repository;

namespace TwenGo.Controllers
{
    public class OrderMController : Controller
    {
        private readonly TwenGoContext _context;

        public OrderMController(TwenGoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.ToList();
            return View(orders);
        }
    }
}
