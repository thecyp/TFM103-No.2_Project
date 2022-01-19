using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class Order
    {
        [DisplayFormat(DataFormatString = "{0:000000}")]
        public int Id { get; set; }

        [Display(Name = "訂單日期")]
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }

        [Display(Name = "使用者名稱")]
        public string UserName { get; set; }

        [Display(Name = "總價")]
        public int Total { get; set; }

        [Required]
        [Display(Name = "預約日期")]
        [DataType(DataType.Date)]
        public DateTime ReciveDate { get; set; }

        [Required]
        [Display(Name = "預約者")]
        public string ReceiverName { get; set; }

        [Required]
        [Display(Name = "預約者地址")]
        public string ReceiverAddress { get; set; }

        [Required]
        [Display(Name = "預約者電話")]
        public string ReceiverPhone { get; set; }
        public string Memo { get; set; }


        [Display(Name = "付款狀態")]
        public bool isPaid { get; set; }
        public List<OrderItem> OrderItem { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int SubTotal { get; set; }
        public int Total { get; set; }
    }

    public class CartItem : OrderItem
    {
        public CartItem() { }
        public CartItem(OrderItem order)
        {
            this.OrderId = order.OrderId;
            this.ProductId = order.ProductId;
            this.Amount = order.Amount;
            this.SubTotal = order.SubTotal;
            this.Total = order.Total;
        }

        public Product Product { get; set; }
        public string imageSrc { get; set; }
    }
}

