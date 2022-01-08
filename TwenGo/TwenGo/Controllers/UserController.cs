using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Models.Repository;
using TwenGo.Models.Repository.Entity;
using TwenGo.Models.ViewModels;

namespace TwenGo.Controllers
{
    public class UserController : Controller
    {
        private readonly TwenGoContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Users> _userManager;
        private readonly ILogger<UserController> _logger;
        public UserController(RoleManager<IdentityRole>roleManager, TwenGoContext twenGoContext, UserManager<Users> userManager, ILogger<UserController> logger) 
        {
            _logger = logger;
            _userManager = userManager;
            _db = twenGoContext;
           _roleManager = roleManager;
        }
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleCreateAsync(RoleViewModel role)
        {
            var data = new Users()
            {
                Id = Guid.NewGuid().ToString(),

                TwenGoRole = new TwenGoRole()
                {
                    RoleName = role.RoleName
                }
            };

            var result = await _userManager.CreateAsync(data);
            if (result.Succeeded)
            {
                var roleExist = await _roleManager.RoleExistsAsync(role.RoleName); //判斷角色是否已存在
                if (!roleExist)
                {
                    var result1 = await _roleManager.CreateAsync(new IdentityRole(role.RoleName));
                }
                else
                {
                    return Content("已經有這角色了");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
