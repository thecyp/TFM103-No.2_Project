using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TwenGo.Models.ViewModels;

namespace TwenGo.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel LoginData)
        {
            var claims = new List<Claim>() { 
            new Claim(ClaimTypes.Name,""),
            new Claim(ClaimTypes.Email,""),
            new Claim(ClaimTypes.Role,"")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var pric = new ClaimsPrincipal(identity);

            return View();
        }
    }
}
