using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
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
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _config;

        public MemberController(ILogger<MemberController> logger, TwenGoContext twenGoContext,UserManager<Users> userManager,IPasswordHasher<Users> passwordHasher, IEmailSender emailSender, IConfiguration config)
        {
            _config = config;
            _emailSender = emailSender;
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

                _logger.LogInformation("User created a new account with password.");
                var userId = await _userManager.GetUserIdAsync(data);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(data);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = "https://servego.azurewebsites.net/Identity/Account/ConfirmEmail?userId=" + userId + "&code=" + code;
                await _emailSender.SendEmailAsync(
                    data.Email,
                    "Email驗證",
                    $"請點選此連結開通帳號 <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>開通連結</a>。");

                ModelState.AddModelError(string.Empty, "確認信已發送，請至您的信箱確認。");

                return RedirectToAction("EmailCheck", "Member");
                

            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        
            
           return RedirectToAction("Index", "Home");

    }

        
        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult EmailCheck()
        {
            return View();
        }
        
    }
}
