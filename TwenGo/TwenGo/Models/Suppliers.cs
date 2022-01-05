using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class Suppliers
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "賣家編號")]
        public int SuppliersID { get; set; }

        [Required]
        [Display(Name = "管理者帳號")]
        public string Account_S { get; set; }

        [Required]
        [Display(Name = "管理者密碼")]
        public string Password_S { get; set; }

        [Required]
        [Display(Name = "管理者信箱")]
        public string Email_S { get; set; }

        [Required]
        [Display(Name = "管理者手機")]
        public string CellPhone_S { get; set; }

        [Required]
        [Display(Name = "公司電話")]
        public string CompanyPhone { get; set; }

        [Required]
        [Display(Name = "企業名稱")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "代表人姓名")]
        public string Representative { get; set; }

        [Required]
        [Display(Name = "代表人身分證字號")]
        public string RepresentativeIdentityNumber { get; set; }

        [Required]
        [Display(Name = "統一編號")]
        public string TaxIDNumber { get; set; }

        [Required]
        [Display(Name = "實收資本額")]
        public string Capital { get; set; }

        [Required]
        [Display(Name = "公司聯絡地址")]
        public string LocationOfCompany { get; set; }

        [Display(Name = "上架圖片")]
        public string MallPicture { get; set; }
    }
}
