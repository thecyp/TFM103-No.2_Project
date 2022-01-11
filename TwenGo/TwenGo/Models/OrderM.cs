using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class OrderM
    {
        [DisplayFormat(DataFormatString = "{0:000000}")]
        public int Id { get; set; }

        [Display(Name = "訂單日期")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "使用者ID")]
        public string UserId { get; set; }
        [Display(Name = "使用者名稱")]
        public string UserName { get; set; }
        [Display(Name = "總價")]
        public int Total { get; set; }

        [Required]
        [Display(Name = "接案者名稱")]
        public string ReceiverName { get; set; }

        [Required]
        [Display(Name = "接案者地址")]
        public string ReceiverAdress { get; set; }

        [Required]
        [Display(Name = "接案者電話")]
        public string ReceiverPhone { get; set; }

        [Display(Name = "付款狀態")]
        public bool isPaid { get; set; }

        public string Status { get; set; }
        public List<OrderItem> OrderItem { get; set; }


    }


}

