using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class Order
    {
        [Key]
        [Required]
        [Display(Name = "訂單編號")]
        public int OrderID { get; set; }

        [Required]
        [Display(Name = "產品編號")]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "產品圖片編號")]
        public int ProductPictureID { get; set; }

        [Required]
        [Display(Name = "訂單狀態")]
        public string OrderStatus { get; set; }

        [Required]
        [Display(Name = "物流狀態")]
        public string ShipStatus { get; set; }
    }
}
