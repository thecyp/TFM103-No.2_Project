using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Data;
using TwenGo.Models;
using TwenGo.Models.Repository;

namespace TwenGo.Controllers
{
    public class GroupController : Controller
    {
        private readonly TwenGoContext db;
        public GroupController(TwenGoContext db)
        {
            
            this.db = db;
        }
        public IActionResult GroupUp(Group group, Product product)
        {
            //db.Products.Add(new Group
            //{
            //    ProductName = product.ProductName,
            //    Price = product.Price,
            //    Quantity = product.Quantity,
            //});
            db.SaveChanges();
            return View();
        }
        //public IActionResult GroupUp(Models.GroupViewModel product)
        //{
        //    db.Products.Add(new Product
        //    {

        //    });
        //    db.SaveChanges();
        //    return Ok($"新增成功!");
        //}
    }
}
