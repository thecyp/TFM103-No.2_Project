using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class Shipper
    {
        [Key]
        [Required]
        [Display(Name = "訂單編號")]
        public int ShipID { get; set; }

        [Required]
        [Display(Name = "公司名稱")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "訂單地區")]
        public string ShipRegion { get; set; }

        [Required]
        [Display(Name = "訂單地址")]
        public string ShipAddress { get; set; }

        [Required]
        [Display(Name = "訂單日期")]
        public string ShipDate { get; set; }

        [Required]
        [Display(Name = "貨運")]
        public string Freight { get; set; }
    }
}
