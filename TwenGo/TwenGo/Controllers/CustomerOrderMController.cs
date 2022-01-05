using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Data;
using TwenGo.Models;

namespace TwenGo.Controllers
{
    public class CustomerOrderMController : Controller
    { 
        private readonly ApplicationDbContext _context;

        public CustomerOrderMController(ApplicationDbContext context)
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
