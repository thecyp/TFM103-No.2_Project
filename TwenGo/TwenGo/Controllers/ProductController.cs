using Microsoft.AspNetCore.Hosting;
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
    public class ProductController : Controller
    {
        public IActionResult Center()
        {
            return View();
        }
        public IActionResult Launch()
        {
            return View();
        }
        public IActionResult ProductView()
        {
            return View();
        }

            private readonly IWebHostEnvironment env;
            private readonly TwenGoContext db;
            private readonly string fileRoot = @"\Pictures\";
        public ProductController(IWebHostEnvironment env, TwenGoContext db)
        {
            this.env = env;
            this.db = db;
        }
        [HttpPost]
        public IActionResult Upload(LaunchViewModel data)
        {
            if ((data.pic.FirstOrDefault()?.Length) <= 0)
            {
                return Ok("nothing");
            }
            var file = data.pic.First();
            var combineFileName = $@"{fileRoot}{DateTime.Now.Ticks}{file.FileName}";
            using (var fileStream = System.IO.File.Create($@"{env.WebRootPath}{combineFileName}"))
            {
                file.CopyTo(fileStream);
            }
            db.Products.Add(new Models.Product
            {
                ProductName = data.ProductName,
                Description = data.Description,
                Price = data.Price,
                Address = data.countyName+data.districtName,
                PicturePath = combineFileName
            });
            db.SaveChanges();
            return View("Center");
        }
    }
}
