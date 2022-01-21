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
        private readonly UserManager<Users> _userManager;
        private readonly IPasswordHasher<Users> passwordHasher;
        private readonly ILogger<AdminController> _logger;


        public AdminController(ILogger<AdminController> logger, TwenGoContext twenGoContext, UserManager<Users> userManager, IPasswordHasher<Users> passwordHasher)
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

            var data = new Users()
            {
                
               RealName=admin.AdminName,
                Id = Guid.NewGuid().ToString(),
                Email=admin.Email,
                IdentityNumber=admin.IdentityNumber,
                UserName=admin.Email,
                NormalizedEmail=admin.Email,
               Town=admin.Town,
               City=admin.City,
               Address=admin.Address,
               
                UserOfAdmin = new UserOfAdmin()
                {
                    JobTitle=admin.JobTitle,
                    EntryDay=admin.EntryDay

                }
            };


            var result = await _userManager.CreateAsync(data, admin.Admin_Password);


            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(data, "Administrator").Wait();
                

            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return RedirectToAction("Index", "Home");

        }




        

    }
}
