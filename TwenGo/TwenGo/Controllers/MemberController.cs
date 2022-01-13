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
               
                Town = customer.Town,
                City = customer.City,
                RealName=customer.CustomerName,
                RememberMe=customer.RememberMe,
                UserName = customer.Email,
                
                IdentityNumber = customer.IdentityNumber,
                NormalizedEmail = customer.Email,
                
                          
                NormalizedUserName = customer.Email,

                UserOfCustomer = new UserOfCustomer()
                {
                    Phone = customer.Phone,
                    CellPhone = customer.CellPhone,
                    Gender = customer.Gender,
                    CustomerPicture = "",
                    Birthday = customer.Birthday
                }
            };
           

            var result = await _userManager.CreateAsync(data,customer.C_Password);
            

            if (result.Succeeded )
            {
                _userManager.AddToRoleAsync(data, "Customer").Wait();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Error");
            }

            
        }

        


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
