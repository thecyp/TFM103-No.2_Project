using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Helper;
using TwenGo.Util;

namespace TwenGo.Models
{
    public class SpGatewayResponse
    {
        public string Status { get; set; }
        public string MerchantId { get; set; }
        public string TradeInfo { get; set; }
        public string TradeSha { get; set; }
        public string Version { get; set; }
        public string Key { get; set; }
        public string Iv { get; set; }
        /// <summary>
        /// 驗證資料正確性
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <returns></returns>
        public bool Validate(string merchantId)
        {
            if (merchantId != MerchantId)
            {
                return false;
            }
            var cryptoHelper = new CryptoHelper(Key, Iv);
            var sha = cryptoHelper.GetSha256String(TradeInfo);
            return sha == TradeSha;
        }

        /// <summary>
        /// Gets the response model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetResponseModel<T>()
        {
            var cryptoHelper = new CryptoHelper(Key, Iv);
            var jsonString = cryptoHelper.DecryptAesString(TradeInfo);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

    }
    //public class SpgatewayResponce
    //{
    //    public int Id { get; set; }
    //    public string Status { get; set; }
    //    public string Message { get; set; }
    //    public string  MerchantID { get; set; }
    //    public int Amt { get; set; }
    //    public string TradeNo { get; set; }
    //    public string MerchantOrderNo { get; set; }
    //    public string PaymentType { get; set; }
    //    public string RespondType { get; set; }
    //    public DateTime PayTime { get; set; }
    //    public string IP { get; set; }
    //}
}
