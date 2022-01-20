using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class SpgatewayResponce
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string  MerchantID { get; set; }
        public int Amt { get; set; }
        public string TradeNo { get; set; }
        public string MerchantOrderNo { get; set; }
        public string PaymentType { get; set; }
        public string RespondType { get; set; }
        public DateTime PayTime { get; set; }
        public string IP { get; set; }
    }
}
