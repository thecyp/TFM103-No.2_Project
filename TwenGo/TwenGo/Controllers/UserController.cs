using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
        private readonly TwenGoContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Users> _userManager;
       
        public UserController(RoleManager<IdentityRole>roleManager, TwenGoContext twenGoContext, UserManager<Users> userManager) 
        {
            
            _userManager = userManager;
            _db = twenGoContext;
           _roleManager = roleManager;
        }
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> RoleCreateAsync(RoleViewModel role)
        {
            
            var roleExist = await _roleManager.RoleExistsAsync(role.RoleName); //判斷角色是否已存在
            
                //_userManager.AddToRoleAsync(data, "Administrator").Wait();
              
                if (!roleExist)
                {
                    var result1 = await _roleManager.CreateAsync(new IdentityRole(role.RoleName));
                }
                else
                {
                    return Content("已經有這角色了");
                }
           
            return RedirectToAction("Index", "Home");
        }
    }
}
