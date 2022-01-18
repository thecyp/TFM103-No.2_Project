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

namespace TwenGo.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly TwenGoContext _context;

        public OrderController(TwenGoContext context)
        {
            _context = context;
        }

        #region 結帳流程

        // 結帳
        public IActionResult Index()
        {
            
            //確認 Session 內存在購物車
            if (SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart") == null)
            {
                return RedirectToAction("Index", "Cart");
            }
            var userid = HttpContext.User.Claims.Where(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").FirstOrDefault().Value;

            //建立新的訂單
            var myOrder = new Order
            {
                UserId = userid,
                OrderItem = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart")
            };
            myOrder.Total = myOrder.OrderItem.Sum(m => m.SubTotal);
            ViewBag.CartItems = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            return View(myOrder);
        }

        // 新增訂單到資料庫
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            //新增訂單到資料庫
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                order.isPaid = false;
                order.OrderItem = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");

                _context.Add(order);
                await _context.SaveChangesAsync();
                SessionHelper.Remove(HttpContext.Session, "cart");

                return RedirectToAction("ReviewOrder", new { Id = order.Id });
            }
            return View();
        }

        // 取得當前訂單
        public async Task<IActionResult> ReviewOrder(int? Id)
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


        #endregion

        // 取得商品詳細資料
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
