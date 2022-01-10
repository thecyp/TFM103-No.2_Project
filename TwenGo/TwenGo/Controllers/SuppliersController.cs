using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Data;
using TwenGo.Models;
using TwenGo.Models.Repository;

namespace TwenGo.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly TwenGoContext _context;

        public SuppliersController(TwenGoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<Supplier> suppliers = _context.Suppliers.ToList();
            return View(suppliers);

        }

        //新增功能
        [HttpGet]
        public IActionResult Create()
        {
            Supplier suppliers = new Supplier();

            return View(suppliers);
        }

        [HttpPost]
        public IActionResult Create(Supplier suppliers)
        {
            _context.Add(suppliers);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        //編輯功能
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Supplier suppliers = _context.Suppliers
                .Where(a => a.SuppliersID == Id).FirstOrDefault();
            return View(suppliers);
        }


        [HttpPost]
        public IActionResult Edit(Supplier suppliers)
        {
            _context.Attach(suppliers);
            _context.Entry(suppliers).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        //查看細節功能
        public IActionResult Details(int Id)
        {
            Supplier suppliers = _context.Suppliers
                .Where(a => a.SuppliersID == Id).FirstOrDefault();
            return View(suppliers);
        }



        //刪除功能
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Supplier suppliers = _context.Suppliers
                .Where(a => a.SuppliersID == Id).FirstOrDefault();
            return View(suppliers);
        }

        [HttpPost]
        public IActionResult Delete(Supplier suppliers)
        {
            _context.Attach(suppliers);
            _context.Entry(suppliers).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
