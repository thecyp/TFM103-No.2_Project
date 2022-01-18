using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Helper;
using TwenGo.Models;
using TwenGo.Models.Repository;
using TwenGo.Models.Repository.Entity;

namespace TwenGo.Controllers
{
    [Authorize]
    public class OrderManagementController : Controller
    {
        private readonly TwenGoContext _context;
        private readonly UserManager<Users> _userManager;

        public async Task<IActionResult> IndexAsync()
        {
            // get logined user
            var user = await this._userManager.GetUserAsync(HttpContext.User);

            // filter orders by user
            List<Order> orders = _context.Orders.ToList();
            var list = (from order in orders
                       where order.UserId == user.Id
                       select order).ToList();
            return View(list);
        }

        public OrderManagementController(TwenGoContext context, UserManager<Users> _userMananger)
        {
            _context = context;
            _userManager = _userMananger;
        }



        ////新增功能
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    Order orders = new Order();

        //    return View(orders);
        //}

        //[HttpPost]
        //public IActionResult Create(Order orders)
        //{
        //    _context.Add(orders);
        //    _context.SaveChanges();
        //    return RedirectToAction("index");
        //}

        public IActionResult Details(int Id)
        {
            Order orders = _context.Orders
                .Where(a => a.Id == Id).FirstOrDefault();
            return View(orders);
        }



        ////刪除功能
        //[HttpGet]
        //public IActionResult Delete(int Id)
        //{
        //    Order orders = _context.Orders
        //        .Where(a => a.Id == Id).FirstOrDefault();
        //    return View(orders);
        //}

        //[HttpPost]
        //public IActionResult Delete(Order orders)
        //{
        //    _context.Attach(orders);
        //    _context.Entry(orders).State = EntityState.Deleted;
        //    _context.SaveChanges();
        //    return RedirectToAction("index");
        //}


    }
}
