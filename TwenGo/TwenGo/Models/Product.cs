using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Display(Name ="產品名稱")]
        public string ProductName { get; set; }
        [Display(Name ="種類")]
        public int Category { get; set; }
        [Display(Name ="單位")]
        public string Quantity { get; set; }
        [Display(Name ="產品簡介")]
        public string Description { get; set; }
        [Display(Name ="售價")]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        [Display(Name ="庫存")]
        public int UnitStock { get; set; }
        
        public string Picture { get; set; }
    }
}
