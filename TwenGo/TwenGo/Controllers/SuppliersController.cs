using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Data;
using TwenGo.Models;

namespace TwenGo.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuppliersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int pg =1)
        {
            const int pageSize = 10;

            if (pg < 1)
                pg = 1;
            int recsCount = _context.Suppliers.Count();
            var supplierpager = new SupplierPager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;


            List<Suppliers> suppliers = _context.Suppliers.Skip(recSkip).Take(pageSize).ToList();
            return View(suppliers);
            //return View();
        }

        //新增功能
        [HttpGet]
        public IActionResult Create()
        {
            Suppliers suppliers = new Suppliers();

            return View(suppliers);
        }

        [HttpPost]
        public IActionResult Create(Suppliers suppliers)
        {
            _context.Add(suppliers);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        //編輯功能
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Suppliers suppliers = _context.Suppliers
                .Where(a => a.SuppliersID == Id).FirstOrDefault();
            return View(suppliers);
        }


        [HttpPost]
        public IActionResult Edit(Suppliers suppliers)
        {
            _context.Attach(suppliers);
            _context.Entry(suppliers).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        //查看細節功能
        public IActionResult Details(int Id)
        {
            Suppliers suppliers = _context.Suppliers
                .Where(a => a.SuppliersID == Id).FirstOrDefault();
            return View(suppliers);
        }



        //刪除功能
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Suppliers suppliers = _context.Suppliers
                .Where(a => a.SuppliersID == Id).FirstOrDefault();
            return View(suppliers);
        }

        [HttpPost]
        public IActionResult Delete(Suppliers suppliers)
        {
            _context.Attach(suppliers);
            _context.Entry(suppliers).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
