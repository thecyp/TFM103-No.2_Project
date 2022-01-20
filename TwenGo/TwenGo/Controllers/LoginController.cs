using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TwenGo.Models.Repository;
using TwenGo.Models.Repository.Entity;
using TwenGo.Models.ViewModels;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace TwenGo.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly TwenGoContext context;
        private readonly ILogger<LoginController> _logger;

        public LoginController(TwenGoContext twenGoContext, SignInManager<Users> signInManager, UserManager<Users>userManager, ILogger<LoginController> logger) 
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            context = twenGoContext;
        }

        [Route("~/Login/Index")]
        public IActionResult Index()
        {
            var h = HttpContext.Request;
            var user = HttpContext.User;
            //var name = user.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault()?.Value;
            //if(name == "") 
            //{
            //    return Content("登入權限為Myth");
            //}
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel LoginData)
        {

            var result = await _signInManager.PasswordSignInAsync(LoginData.Email, LoginData.Password, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                

                return RedirectToAction("Index", "Home");
            }



            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Customer")]
        //登入檢測頁面
        [Route("~/Login/CheckLogin")]
        public IActionResult CheckLogin()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {

                var ss = HttpContext.User.Claims.Where(x => x.Type == "Customer").FirstOrDefault()?.Value;
                if (ss == "true")
                {
                    return Content("你是Customer");
                }
                else
                {
                    return Content("你是其他的");
                }


            }
          
            
            return RedirectToAction("Index", "Login");
        }


       
    }
}
