using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpGatewayHelper;
using SpGatewayHelper.Helper;
using SpGatewayHelper.Models;
using System;
using System.Diagnostics;
using TwenGo.Models.ViewModels;

namespace TwenGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _key;
        private readonly string _Iv;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _key = "poClKoJFuSuCgQfDK4ILyB4EDzpkMBqW";
            _Iv = "CZuzunOnS2uFGmnP";
        }

        public ActionResult Index()
        {
            var tradeInfo = new TradeInfo()
            {
                MerchantID = "MS130230614",
                RespondType = "JSON",
                TimeStamp = DateTime.Now.ToUnixTimeStamp(),
                Version = "1.5",
                Amt = 100,
                ItemDesc = "TTEESSTT",
                //InstFlag="3,6",
                //CreditRed = 0,
                Email = "a105030102@gmail.com",
                EmailModify = 0,
                LoginType = 0,
                MerchantOrderNo = DateTime.Now.Ticks.ToString(),
                TradeLimit = 180,
                //CVS=1,
                //ExpireDate=DateTime.Now.ToString("yyyyMMdd"),
                ReturnURL = "https://localhost:5001/Home/index",
            };
            var postData = tradeInfo.ToDictionary();
            var cryptoHelper = new CryptoHelper(_key, _Iv);
            var aesString = cryptoHelper.GetAesString(postData);
            ViewData["TradeInfo"] = aesString;
            ViewData["TradeSha"] = cryptoHelper.GetSha256String(aesString);
            return PartialView();
        }

        [HttpPost]
        public ActionResult Index(SpGatewayResponse response)
        {
            response.Key = _key;
            response.Vi = _Iv;
            var success = response.Validate("MS12345678");
            if (success)
            {
                var tradInfoModel = response.GetResponseModel<TradeInfoModel>();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string Name)
        {

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string Name)
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
