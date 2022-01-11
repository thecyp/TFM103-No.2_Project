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
    public class AdminController : Controller
    {
        private readonly TwenGoContext _db;
        private readonly UserManager<UserOfAdmin> _userManager;
        private readonly IPasswordHasher<UserOfAdmin> passwordHasher;
        private readonly ILogger<AdminController> _logger;
        public AdminController(TwenGoContext twenGoContext, UserManager<UserOfAdmin> userManager, IPasswordHasher<UserOfAdmin> passwordHasher, ILogger<AdminController> logger) 
        {
            _db = twenGoContext;
            _userManager = userManager;
            this.passwordHasher = passwordHasher;
            _logger = logger;
        }
        public IActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminRegisterAsync(AdminViewModel admin) 
        {
            var data = new UserOfAdmin()
            {
                

            };
            var result = await _userManager.CreateAsync(data, admin.Admin_Password);
            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(data, "Administrator").Wait();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
