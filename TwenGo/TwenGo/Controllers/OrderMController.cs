using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Data;
using TwenGo.Models;

namespace TwenGo.Controllers
{
    public class OrderMController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderMController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //List<Shipper> shippers;
            //shippers = _context.Shipper.ToList();
            //return View(shippers);
            return View();
        }
    }
}
