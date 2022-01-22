using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Spgateway.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Web;
using ThirdPartyPay.Models;
using TwenGo.Models;
using TwenGo.Models.Repository;
using TwenGo.Util;

namespace TwenGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly TwenGoContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly BankInfoModel _bankInfoModel;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, TwenGoContext context)
        {
            _context = context;
            _logger = logger;
            this.httpContextAccessor = httpContextAccessor;
            _bankInfoModel = new BankInfoModel
            {
                MerchantID = "MS130347314",
                HashKey = "7Ybh4jR2L41C3v1JUlax9eduyMBwBxmv",
                HashIV = "CumZ6y4XhGDUAOVP",
                ReturnURL = "https://servego.azurewebsites.net/Home/SpgatewayReturn",
                NotifyURL = "",
                CustomerURL = "",
                AuthUrl = "https://ccore.spgateway.com/MPG/mpg_gateway",
                CloseUrl = "https://core.newebpay.com/API/CreditCard/Close"
            };



        }

        public IActionResult PayReturn()
        {



            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /// <summary>
        /// [智付通支付]金流介接
        /// </summary>
        /// <param name="ordernumber">訂單單號</param>
        /// <param name="amount">訂單金額</param>
        /// <param name="payType">請款類型</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SpgatewayPayBillAsync(string productname, string ordernumber, int amount, string payType)
        {
            string version = "1.5";

            // 目前時間轉換 +08:00, 防止傳入時間或Server時間時區不同造成錯誤
            DateTimeOffset taipeiStandardTimeOffset = DateTimeOffset.Now.ToOffset(new TimeSpan(8, 0, 0));

            var userid = HttpContext.User.Claims.Where(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").FirstOrDefault().Value;
            var aaa = _context.Orders.Where(x => x.UserId == userid).ToList();
            TradeInfo tradeInfo = new TradeInfo()
            {
                // * 商店代號
                MerchantID = _bankInfoModel.MerchantID,
                // * 回傳格式
                RespondType = "String",
                // * TimeStamp
                TimeStamp = taipeiStandardTimeOffset.ToUnixTimeSeconds().ToString(),
                // * 串接程式版本
                Version = version,
                // * 商店訂單編號
                //MerchantOrderNo = $"T{DateTime.Now.ToString("yyyyMMddHHmm")}",
                MerchantOrderNo = ordernumber,
                // * 訂單金額
                Amt = amount,
                // * 商品資訊
                ItemDesc = productname,
                // 繳費有效期限(適用於非即時交易)
                ExpireDate = null,
                // 支付完成 返回商店網址
                ReturnURL = _bankInfoModel.ReturnURL,
                // 支付通知網址
                NotifyURL = _bankInfoModel.NotifyURL,
                // 商店取號網址
                CustomerURL = _bankInfoModel.CustomerURL,
                // 支付取消 返回商店網址
                ClientBackURL = null,
                // * 付款人電子信箱
                Email = string.Empty,
                // 付款人電子信箱 是否開放修改(1=可修改 0=不可修改)
                EmailModify = 0,
                // 商店備註
                OrderComment = null,
                // 信用卡 一次付清啟用(1=啟用、0或者未有此參數=不啟用)
                CREDIT = null,
                // WEBATM啟用(1=啟用、0或者未有此參數，即代表不開啟)
                WEBATM = null,
                // ATM 轉帳啟用(1=啟用、0或者未有此參數，即代表不開啟)
                VACC = null,
                // 超商代碼繳費啟用(1=啟用、0或者未有此參數，即代表不開啟)(當該筆訂單金額小於 30 元或超過 2 萬元時，即使此參數設定為啟用，MPG 付款頁面仍不會顯示此支付方式選項。)
                CVS = null,
                // 超商條碼繳費啟用(1=啟用、0或者未有此參數，即代表不開啟)(當該筆訂單金額小於 20 元或超過 4 萬元時，即使此參數設定為啟用，MPG 付款頁面仍不會顯示此支付方式選項。)
                BARCODE = null
            };

            if (string.Equals(payType, "CREDIT"))
            {
                tradeInfo.CREDIT = 1;
            }
            else if (string.Equals(payType, "WEBATM"))
            {
                tradeInfo.WEBATM = 1;
            }
            else if (string.Equals(payType, "VACC"))
            {
                // 設定繳費截止日期
                tradeInfo.ExpireDate = taipeiStandardTimeOffset.AddDays(1).ToString("yyyyMMdd");
                tradeInfo.VACC = 1;
            }
            else if (string.Equals(payType, "CVS"))
            {
                // 設定繳費截止日期
                tradeInfo.ExpireDate = taipeiStandardTimeOffset.AddDays(1).ToString("yyyyMMdd");
                tradeInfo.CVS = 1;
            }
            else if (string.Equals(payType, "BARCODE"))
            {
                // 設定繳費截止日期
                tradeInfo.ExpireDate = taipeiStandardTimeOffset.AddDays(1).ToString("yyyyMMdd");
                tradeInfo.BARCODE = 1;
            }

            //Atom<string> result = new Atom<string>()
            //{
            //    IsSuccess = true
            //};

            var inputModel = new SpgatewayInputModel
            {
                MerchantID = _bankInfoModel.MerchantID,
                Version = version
            };

            // 將model 轉換為List<KeyValuePair<string, string>>, null值不轉
            List<KeyValuePair<string, string>> tradeData = Util.LambdaUtil.ModelToKeyValuePairList<TradeInfo>(tradeInfo);
            // 將List<KeyValuePair<string, string>> 轉換為 key1=Value1&key2=Value2&key3=Value3...
            var tradeQueryPara = string.Join("&", tradeData.Select(x => $"{x.Key}={x.Value}"));
            // AES 加密
            inputModel.TradeInfo = Util.CryptoUtil.EncryptAESHex(tradeQueryPara, _bankInfoModel.HashKey, _bankInfoModel.HashIV);
            // SHA256 加密
            inputModel.TradeSha = Util.CryptoUtil.EncryptSHA256($"HashKey={_bankInfoModel.HashKey}&{inputModel.TradeInfo}&HashIV={_bankInfoModel.HashIV}");

            // 將model 轉換為List<KeyValuePair<string, string>>, null值不轉
            List<KeyValuePair<string, string>> postData = Util.LambdaUtil.ModelToKeyValuePairList<SpgatewayInputModel>(inputModel);
            httpContextAccessor.HttpContext.Response.Clear();

            StringBuilder s = new StringBuilder();
            s.Append("<html>");
            s.AppendFormat("<body onload='document.forms[\"form\"].submit()'>");
            s.AppendFormat("<form name='form' action='{0}' method='post'>", _bankInfoModel.AuthUrl);
            foreach (KeyValuePair<string, string> item in postData)
            {
                s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", item.Key, item.Value);
            }
            s.Append("</form></body></html>");
            await httpContextAccessor.HttpContext.Response.WriteAsync(s.ToString());
            await httpContextAccessor.HttpContext.Response.CompleteAsync();
            return Content(string.Empty);
        }

        /// <summary>
        /// [智付通]金流介接(結果: 支付完成 返回商店網址)
        /// </summary>
        [HttpPost]
        public ActionResult SpgatewayReturn()
        {
            // Status 回傳狀態 
            // MerchantID 回傳訊息
            // TradeInfo 交易資料AES 加密
            // TradeSha 交易資料SHA256 加密
            // Version 串接程式版本
            var collection = HttpContext.Request.Form;
            if (string.Equals(collection["MerchantID"], _bankInfoModel.MerchantID) &&
                string.Equals(collection["TradeSha"], CryptoUtil.EncryptSHA256($"HashKey={_bankInfoModel.HashKey}&{collection["TradeInfo"]}&HashIV={_bankInfoModel.HashIV}")))
            {
                var decryptTradeInfo = CryptoUtil.DecryptAESHex(collection["TradeInfo"], _bankInfoModel.HashKey, _bankInfoModel.HashIV);

                // 取得回傳參數(ex:key1=value1&key2=value2),儲存為NameValueCollection
                NameValueCollection decryptTradeCollection = HttpUtility.ParseQueryString(decryptTradeInfo);
                SpgatewayOutputDataModel convertModel = LambdaUtil.DictionaryToObject<SpgatewayOutputDataModel>(decryptTradeCollection.AllKeys.ToDictionary(k => k, k => decryptTradeCollection[k]));


                // TODO 將回傳訊息寫入資料庫
                _context.SpgatewayOutputDataModels.Add(convertModel);
                var reChar = convertModel.MerchantOrderNo.ToArray();
                var notZero = reChar.FirstOrDefault(x => x != '0');
                int index =  new string(reChar).IndexOf(notZero);
                convertModel.MerchantOrderNo = convertModel.MerchantOrderNo.Substring(index, reChar.Length - index);
                var changeOId = _context.Orders.FirstOrDefault(x => (x.Id.ToString() == convertModel.MerchantOrderNo) && (!x.isPaid)).isPaid=true;
                _context.SaveChanges();

                return RedirectToAction("SpgatewayReturnView", convertModel);
            }

            return Content("交易失敗! 請重新嘗試付款!");
        }


        public ActionResult SpgatewayReturnView(SpgatewayOutputDataModel data)
        {
            return View(data);        
        }
    }

}
