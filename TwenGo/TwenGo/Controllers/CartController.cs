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
    public class CartController : Controller
    {
        private readonly TwenGoContext _context;


        public CartController(TwenGoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<Product> GetProduct()
        {
            return _context.Products.ToList();
        }

        public List<CartViewModel> GetCart()
        {
            //向 Session 取得商品列表
            List<CartItem> CartItems = SessionHelper.
                GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            if (CartItems != null)
            {
                var temp = CartItems.Select(x => x.Product.Id);
                var findProducts = _context.Products.Where(x => temp.Contains(x.Id)).ToList();
                return findProducts.Select(x => new CartViewModel
                {
                    Id = x.Id,
                    Image = x.PicturePath,
                    Name = x.ProductName,
                    Price = x.Price,
                    Description = x.Description,
                    Amount = CartItems.Single(z => z.ProductId == x.Id).Amount,
                    Subtotal = x.Price * CartItems.Single(z => z.ProductId == x.Id).Amount,
                    Total = CartItems.Sum(z => z.SubTotal)
                }).ToList();
            }
            else
            {
                return new List<CartViewModel>();
            }
        }


        [HttpPost]
        public IActionResult AddtoCart([FromForm] int id)
        {
            var product = _context.Products.Single(x => x.Id.Equals(id));
            //取得商品資料
            CartItem item = new CartItem
            {
                ProductId = product.Id,
                Product = product,
                Amount = 1,
                SubTotal = product.Price,
                imageSrc = product.PicturePath
            };
            //判斷 Session 內有無購物車
            if (SessionHelper.
                GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                //如果沒有已存在購物車: 建立新的購物車
                List<CartItem> cart = new List<CartItem>();
                cart.Add(item);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                //如果已存在購物車: 檢查有無相同的商品，有的話只調整數量
                List<CartItem> cart = SessionHelper.
                    GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

                int index = cart.FindIndex(m => m.Product.Id.Equals(id));
                if (index != -1)
                {
                    cart[index].Amount += item.Amount;
                    cart[index].SubTotal += item.SubTotal;
                }
                else
                {
                    cart.Add(item);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return NoContent(); // HttpStatus 204: 請求成功但不更新畫面
        }
        [HttpPost]
        public IActionResult CleanCart([FromForm] int id)
        {
            //向 Session 取得商品列表
            List<CartItem> cart = SessionHelper.
                GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            //用FindIndex查詢目標在List裡的位置
            int index = cart.FindIndex(m => m.Product.Id.Equals(id));
            cart.RemoveAt(index);

            if (cart.Count < 1)
            {
                SessionHelper.Remove(HttpContext.Session, "cart");
            }
            else
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }


            return NoContent();

        }

    }
}
