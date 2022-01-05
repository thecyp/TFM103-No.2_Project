using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models.ViewModels
{
    public class SupplierViewModel
    {
        [MaxLength(25)]
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "代表人姓名")]
        public string RepresentativeName { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "代表人身分證字號")]
        [RegularExpression(@"^[A-Z]{1}[1-2]{1}[0-9]{8}$", ErrorMessage = "請輸入正確格式")]
        public string RepresentativeIdentityNumber { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "請輸入{0}")]
        [EmailAddress]
        [Display(Name = "信箱")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string SupplierEmail { get; set; }

        [MaxLength(30)]
        [DataType(DataType.Password)]//默認生成的是密碼框而不是文字框
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "密碼")]
        public string Password_S { get; set; }

        [NotMapped]
        [Compare("Password_S", ErrorMessage = "密碼不相符")]
        [Display(Name = "請再輸入一次密碼")]
        [DataType(DataType.Password)]
        public string ConfirmPassword_S { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "代表人手機號碼")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "請輸入正確格式")]
        public string CellPhone { get; set; }

        [MaxLength(9)]
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "公司聯絡電話")]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "請輸入正確格式")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "企業名稱")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "請輸入{0}")]
        [MaxLength(8)]
        [Display(Name = "統一編號")]
        [RegularExpression(@"([0-9]{8}[^a-zA-Z])", ErrorMessage = "請輸入正確格式")]
        public string TaxIDNumber { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "實收資本額")]
        [RegularExpression(@"^(0|[1-9][0-9]*)$", ErrorMessage = "請輸入正確格式")]
        public string Capital { get; set; }

        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "城市")]
        public string City { get; set; }

        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "區域")]
        public string Town { get; set; }

        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "地址")]
        public string Address { get; set; }
    }
}
