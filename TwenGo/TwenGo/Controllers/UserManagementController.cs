using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Helper;
using TwenGo.Models.Repository;
using TwenGo.Models.Repository.Entity;
using TwenGo.Models.ViewModels;

namespace TwenGo.Controllers
{
    [Authorize(Roles = "Administrator")]
    //[Authorize]
    public class UserManagementController : Controller
    {
        private readonly TwenGoContext _context;
        private readonly UserManager<Users> _userManager;

        public UserManagementController(TwenGoContext context, UserManager<Users> _userMananger)
        {
            _context = context;
            _userManager = _userMananger;
        }



        public IActionResult Index()
        {
            List<Users> users = _context.Users.ToList();
            //var a =_userManager.GetUserId(User);
            //Console.WriteLine(a);
            //Users users = _context.Users
            //   .Where(a => a.Id == Id).FirstOrDefault();
            return View(users);

            //List<CustomerViewModel> customerViewModels = _context.CustomerViewModels.ToList();
        }

        //新增功能

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    Users users = new Users();
        //    return View(users);
        //}

        //[HttpPost]
        //public IActionResult Create(Users users)
        //{
        //    _context.Add(users);
        //    _context.SaveChanges();
        //    return RedirectToAction("index");
        //}

        //刪除功能
        //[HttpGet]
        //public IActionResult Delete(string Id)
        //{

        //    Users users = _context.Users
        //        .Where(a => a.Id == Id).FirstOrDefault();

        //    return View(users);
        //}

        //[HttpPost]
        //public IActionResult Delete(Users users)
        //{

        //    _context.Users.Remove(users);
        //    _context.SaveChanges();

        //    return RedirectToAction("index");
        //}


    }
}
