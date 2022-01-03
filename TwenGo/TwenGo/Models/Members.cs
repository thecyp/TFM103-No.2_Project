using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class Members
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "會員編號")]
        public int MemberID { get; set; }

       
        [Display(Name = "帳號")]
        
        public string Account { get; set; }

       
       
        [Display(Name = "密碼")]
        public string Password { get; set; }

        
        [Display(Name = "身分證字號")]
        public string IdentityNumber { get; set; }

        
       
        [Display(Name = "信箱")]
        public string Email { get; set; }

        
        
        [Display(Name = "手機號碼")]
        public string Phone { get; set; }

        
        [Display(Name = "國家")]
        public string Country { get; set; }

       
        [Display(Name = "城市")]
        public string City { get; set; }

        
        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "新增日期")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "最後修改日期")]
        public DateTime EditDate { get; set; }

        [ForeignKey("Customers")]
        public int CustomerID { get; set; }

        [ForeignKey("Suppliers")]
        public int SuppliersID { get; set; }
    }
}
