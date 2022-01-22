using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TwenGo.Data;
using TwenGo.Models;
using TwenGo.Models.Repository;

namespace TwenGo.Controllers.API
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly TwenGoContext _context;
        private readonly string fileRoot = @"\Pictures\";

        public ProductsController(IWebHostEnvironment env, TwenGoContext context)
        {
            this.env = env;
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            //var j = JsonSerializer.Serialize(product);

            return product;
        }

        // PUT: api/Products/5
        [HttpPut]
        [Route("{id}")]
        [Consumes("multipart/form-data")]
        public void Put([FromRoute]int id,[FromForm] LaunchViewModel product)
        {
            var combineFileName = "";
            if (product.img !=null)
            {
                var file = product.img.First();
                combineFileName = $@"{fileRoot}{DateTime.Now.Ticks}{file.FileName}";
                using (var fileStream = System.IO.File.Create($@"{env.WebRootPath}{combineFileName}"))
                {
                    file.CopyTo(fileStream);
                }
            }
            var edit = _context.Products.Find(id);

            if (edit != null)
            {
                edit.ProductName = product.ProductName;
                edit.Description = product.Description;
                edit.Price = product.Price;
                edit.Address = product.countyName + product.districtName;
                edit.PicturePath = combineFileName == "" ? edit.PicturePath : combineFileName;

                _context.SaveChanges();
            }
        }

        // POST: api/Products
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var delete = await _context.Products.FindAsync(id);
            if (delete == null)
            {
                return NotFound();
            }
            _context.Products.Remove(delete);
            await _context.SaveChangesAsync();

            return Ok("刪除成功");
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
