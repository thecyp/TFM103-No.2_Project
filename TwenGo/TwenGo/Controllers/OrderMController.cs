using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //新增功能
        [HttpGet]
        public IActionResult Create()
        {
            Order orders = new Order();

            return View(orders);
        }

        [HttpPost]
        public IActionResult Create(Order orders)
        {
            _context.Add(orders);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id)
        {
            Order orders = _context.Orders
                .Where(a => a.Id == Id).FirstOrDefault();
            return View(orders);
        }



        //刪除功能
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Order orders = _context.Orders
                .Where(a => a.Id == Id).FirstOrDefault();
            return View(orders);
        }

        [HttpPost]
        public IActionResult Delete(Order orders)
        {
            _context.Attach(orders);
            _context.Entry(orders).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }


    }
}
