using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Helper;
using TwenGo.Models;
using TwenGo.Models.Repository;

namespace TwenGo.Controllers
{
    public class OrderController : Controller
    {
        //private readonly TwenGoContext _context;
        //private readonly UserManager<IdentityUser> _userManager;

        //public OrderController(TwenGoContext context,UserManager<IdentityUser> userManager)
        //{
        //    _context = context;
        //    _userManager = userManager;
        //}

        public IActionResult Index()
        {
            return View();
        }


        //// 結帳
        //[HttpPost]
        //public IActionResult Checkout()
        //{
        //    //確認 Session 內存在購物車
        //    if (SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart") == null)
        //    {
        //        return RedirectToAction("Index", "Cart");
        //    }

        //    //建立新的訂單
        //    var myOrder = new Order()
        //    {
        //        UserId = _userManager.GetUserId(User),
        //        UserName = _userManager.GetUserName(User),
        //        OrderItem = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart")
        //    };
        //    myOrder.Total = myOrder.OrderItem.Sum(m => m.SubTotal);
        //    ViewBag.CartItems = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

        //    return View(myOrder);
        //}
    }
}
