using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Helper;
using TwenGo.Models;
using TwenGo.Models.Repository;
using TwenGo.Models.Repository.Entity;


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



        public IActionResult Index(int pg=1)
        {
            List<Users> users = _context.Users.ToList();
            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int recsCount = users.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;

            var data = users.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

   
            return View(data);
        }

        //刪除功能
        [HttpGet]
        public IActionResult Delete(string Id)
        {

            Users users = _context.Users
                .Where(a => a.Id == Id).FirstOrDefault();

            return View(users);
        }

        [HttpPost]
        public IActionResult Delete(Users users)
        {
            //_context.Attach(users);
            //_context.Users.Remove(users).State = EntityState.Deleted;
            _context.Users.Remove(_context.Users.Find(users.Id));
            _context.SaveChanges();

            return RedirectToAction("index");
        }





    }
}
