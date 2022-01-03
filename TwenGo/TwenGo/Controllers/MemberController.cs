using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TwenGo.Models.Repository;
using TwenGo.Models.Repository.Entity;
using TwenGo.Models.ViewModels;

namespace TwenGo.Controllers
{
    public class MemberController : Controller
    {
        private readonly TwenGoContext _db;
        private readonly UserManager<Users> _userManager;
        private readonly IPasswordHasher<Users> passwordHasher;
        private readonly ILogger<MemberController> _logger;


        public MemberController(ILogger<MemberController> logger, TwenGoContext twenGoContext,UserManager<Users> userManager,IPasswordHasher<Users> passwordHasher)
        {
            _db = twenGoContext;
            _userManager = userManager;
            this.passwordHasher = passwordHasher;
            _logger = logger;
        }

       

        public IActionResult CustomerRegister()
        {
            
            return View();
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomerRegisterAsync(CustomerViewModel customer)
        {
            var data = new Users()
            {
                Address = customer.Address,
                Email = customer.Email,
                Id = Guid.NewGuid().ToString(),
                Phone = customer.Phone,
                Town = customer.Town,
                City = customer.City,
                UserName = customer.Email,
                IdentityNumber = customer.IdentityNumber,
                NormalizedEmail = customer.Email,
                PhoneNumber = customer.CellPhone,
                CellPhone = customer.CellPhone,
                NormalizedUserName = customer.CustomerName,                
                UserOfCustomer = new UserOfCustomer() { 
                    Gender = customer.Gender,
                    CustomerPicture = "",
                    Birthday = customer.Birthday                   
                }
            };
            var result = await _userManager.CreateAsync(data,customer.C_Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult SupplierRegister()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SupplierRegister(int id)
        {
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
