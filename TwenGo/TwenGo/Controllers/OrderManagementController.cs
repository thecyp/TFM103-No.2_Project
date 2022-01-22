using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

        public OrderManagementController(TwenGoContext context, UserManager<Users> _userMananger)
        {
            _context = context;
            _userManager = _userMananger;
        }

        public async Task<IActionResult> IndexAsync(int pg=1)
        {
            // get logined user
            var user = await this._userManager.GetUserAsync(HttpContext.User);

            // filter orders by user
            List<Order> orders = _context.Orders.Where(m=>m.UserId==user.Id && m.isPaid == false).ToList();

            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int recsCount = orders.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;

      
            var list = (from order in orders
                       where order.UserId == user.Id
                       where order.isPaid ==false
                       select order).Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(list);
        }

        public async Task<IActionResult> HistoryOrderAsync(int pg = 1)
        {
            // get logined user
            var user = await this._userManager.GetUserAsync(HttpContext.User);

            // filter orders by user
            List<Order> orders = _context.Orders.Where(m => m.UserId == user.Id && m.isPaid==true).ToList();

            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int recsCount = orders.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;


            var list = (from order in orders
                        where order.UserId == user.Id
                        where order.isPaid == true
                        select order).Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(list);
        }

        public async Task<IActionResult> DetailsAsync(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == Id);


            order.OrderItem = await _context.OrderItem.Where(p => p.OrderId == Id).ToListAsync();
            ViewBag.orderItems = GetOrderItems(order.Id);

            return View(order);        
        }

        //刪除功能
        //[HttpGet]
        //public async Task<IActionResult> DeleteAsync(int Id)
        //{
        //    //Order order = _context.Orders
        //    //    .Where(a => a.Id == Id).FirstOrDefault();
        //    var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == Id);
        //    order.OrderItem = await _context.OrderItem.Where(p => p.OrderId == Id).ToListAsync();
        //    ViewBag.orderItems = GetOrderItems(order.Id);

        //    return View(order);
        //}

        //[HttpPost]
        //public IActionResult Delete(Order order)
        //{
        //    _context.Attach(order);
        //    _context.Entry(order).State = EntityState.Deleted;
        //    _context.SaveChanges();
        //    return RedirectToAction("index");
        //}

        private List<CartItem> GetOrderItems(int orderId)
        {

            var OrderItems = _context.OrderItem.Where(p => p.OrderId == orderId).ToList();

            List<CartItem> orderItems = new List<CartItem>();
            foreach (var orderitem in OrderItems)
            {
                CartItem item = new CartItem(orderitem);
                item.Product = _context.Products.Single(x => x.Id == orderitem.ProductId);
                orderItems.Add(item);
            }

            return orderItems;
        }
    }
}
