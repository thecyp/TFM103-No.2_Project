﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwenGo.Data;
using TwenGo.Models;
using TwenGo.Models.Repository;

namespace TwenGo.Controllers.API
{
    [Route("api/[controller]/[action]")]
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

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
        }


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

            return NoContent();
        }

        // DELETE: api/Products/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct1(string id)
        //{

        //    return Ok(id);
        //}


        //// DELETE: api/Products/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{

        //    return Ok(id);
        //}

        //[HttpPost("delete/{id}")]
        //public IEnumerable<Product> DeProduct(Product id)
        //{
        //    var delete = _context.Product.Find(id.ProductID);
        //    if (delete == null)
        //    {
        //        return (IEnumerable<Product>)NotFound();
        //    }
        //    _context.Products.Remove(delete);
        //    _context.SaveChangesAsync();
        //    return (IEnumerable<Product>)NoContent();
        //}

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
