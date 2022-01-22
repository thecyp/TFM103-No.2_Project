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
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using GoogleRecaptcha;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

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
             
            return View();
        }

                

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel LoginData)
        {
            var apiKey = "6LdNAy4eAAAAAKpRqJUNHxi96ac7JjYEI2W7rhru";
            var url = "https://www.google.com/recaptcha/api/siteverify";
            var wc = new System.Net.WebClient();
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var data = "secret=" + apiKey + "&response=" + Request.Form["g-recaptcha-response"];
            var json = wc.UploadString(url, data);
            // JSON 反序化取 .success 屬性 true/false 判斷
            var success = JsonConvert.DeserializeObject<JObject>(json).Value<bool>("success");
            if (!success)
            {
                return RedirectToAction("Index", "Login");

            }
            // TODO: 檢查帳號密碼
            var result2 = await _signInManager.PasswordSignInAsync(LoginData.Email, LoginData.Password, true, lockoutOnFailure: false);
            if (result2.Succeeded)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }



            
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
