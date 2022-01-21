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
        public async Task<IActionResult> IndexAsync()
        {
                // get logined user
                var user = await this._userManager.GetUserAsync(User);

                // filter orders by user
                List<Users> users = _context.Users.ToList();
                var list = (from u in users
                            where u.RealName == user.RealName
                            select u).ToList();
                return View(list);

            //var data = new CustomerViewModel()
            //{
            //    CustomerName = "123",
            //    Email = "AAA",

            //};

            //return View();

        }

        public ActionResult EditProfileAsync(CustomerViewModel customer)
        {
           
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
