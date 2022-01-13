using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Models.Repository;
using TwenGo.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using TwenGo.Models.Repository.Entity;

namespace TwenGo.Controllers
{
    //[Authorize]
    public class UserCenterController : Controller
    {
        private readonly TwenGoContext _context;
        private readonly UserManager<Users> _userManager;

        public UserCenterController(TwenGoContext context, UserManager<Users> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            //var aaa = HttpContext.User.Identity.Name;

            //var data = new CustomerViewModel()
            //{
            //    CustomerName = "123",
            //    Email = "AAA",
                
            //};

            return View();

        }



        //[HttpGet]
        //public IActionResult Edit(string Id)
        //{
        //    CustomerViewModel customerviewmodels = _context.CustomerViewModels
        //        .Where(a => a.UserId == Id).FirstOrDefault();
        //    return View(customerviewmodels);
        //}

        //[HttpPost]
        //public IActionResult Edit(CustomerViewModel customerviewmodels)
        //{
        //    _context.Attach(customerviewmodels);
        //    _context.Entry(customerviewmodels).State = EntityState.Modified;
        //    _context.SaveChanges();
        //    return RedirectToAction("index");
        //}



    }
}
