﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwenGo.Data;
using TwenGo.Models;
using TwenGo.Models.Repository;

namespace TwenGo.Controllers.API
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly TwenGoContext _context;

        public ProductsController(TwenGoContext context)
        {
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
        [HttpPut("{id}")]
        public void Put(int id,[FromRoute] Product product)
        {
            
            var edit = _context.Products.Find(id);
           
            if (edit != null)
            {
                edit.ProductName = product.ProductName;
                edit.Address = product.Address;
                edit.Description = product.Description;
                edit.Price = product.Price;
                edit.PicturePath = product.PicturePath;
                _context.SaveChanges();
            }
        //    ====================================================
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return NoContent();
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProduct(int id)
        //{
        //    var edit = await _context.Products.FindAsync(id);
        //    if (edit == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Products.Update(edit);
        //    await _context.SaveChangesAsync();

        //    return Ok("更新成功");
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
