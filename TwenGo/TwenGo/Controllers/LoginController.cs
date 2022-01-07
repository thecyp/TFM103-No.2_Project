using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TwenGo.Models.Repository;
using TwenGo.Models.Repository.Entity;
using TwenGo.Models.ViewModels;

namespace TwenGo.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<Users> _signInManager;
        private readonly TwenGoContext context;
        
        public LoginController(TwenGoContext twenGoContext, SignInManager<Users> signInManager) 
        {
            _signInManager = signInManager;
            context = twenGoContext;
        }
        
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

      
        //登入檢測頁面
        public IActionResult CheckLogin() 
        {
            if (HttpContext.User.Identity.IsAuthenticated) 
            {
                if (HttpContext.User.Identity.Name== ClaimTypes.Name) 
                {
                    return Content("歡迎登入");
                }

                
                var ss = HttpContext.User.Claims.Where(x => x.Type == "Customer").FirstOrDefault().Value;
                if( ss == "true") 
                {
                    return Content("你是Customer");
                }
                else 
                {
                    return Content("你是其他的");
                }
                
               
            }
            else 
            {
                //登入失敗時直接導回 登入頁面
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel LoginData)
        {

            var result = await _signInManager.PasswordSignInAsync(LoginData.Email, LoginData.Password, true, lockoutOnFailure: false);
            //去資料庫查使用者
            //var user = context.Users.Where(u => u.Email == LoginData.Email ).FirstOrDefault();
            //if(user == null) 
            //{
            //    return Content("帳號密碼錯誤");
            //}

            //var claims = new List<Claim>() { 
            //new Claim(ClaimTypes.Name,user.UserName),
            //new Claim(ClaimTypes.Email,user.Email),
            //new Claim(ClaimTypes.Role,"Myth"),

            //new Claim("Customer","true")
            //};

            //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //var principal = new ClaimsPrincipal(identity);

            //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            ////SignInAsync幫你做登入這件事 登入的時候就把Cookie丟給使用者來做辨識
            ////自動幫Waston生產一張Claim做登入
            //return RedirectToAction("Index", "Home");
            //Redirect 重新定向
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LoginFailed()
        {
            return View();

        }

        [HttpPost]
        public IActionResult LoginFailed(LoginViewModel FailData)
        {
            return View();

        }
    }
}
