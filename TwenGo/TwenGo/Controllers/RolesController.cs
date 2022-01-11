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
    
    public class RolesController : Controller
    {
        private readonly TwenGoContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Users> _userManager;
       
        public RolesController(RoleManager<IdentityRole>roleManager, TwenGoContext twenGoContext, UserManager<Users> userManager) 
        {
            
            _userManager = userManager;
            _db = twenGoContext;
           _roleManager = roleManager;
        }

        //[Authorize(Roles = "Administrator")]
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> RoleCreateAsync(RoleViewModel role)
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
            
            return RedirectToAction("Index", "Home");
        }
    }
}
