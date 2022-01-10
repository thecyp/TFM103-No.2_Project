using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models.ViewModels
{
    public class AdminViewModel
    {
        [MaxLength(25)]
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "姓名")]
        public string AdminName { get; set; }

        [MaxLength(10)]
        [Display(Name = "職稱")]
        [Required]
        public string JobTitle { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "身分證字號")]
        [RegularExpression(@"^[A-Z]{1}[1-2]{1}[0-9]{8}$", ErrorMessage = "請輸入正確格式")]
        public string IdentityNumber { get; set; }

        [MaxLength(30)]
        [DataType(DataType.Password)]//默認生成的是密碼框而不是文字框
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "密碼")]
        public string Admin_Password { get; set; }

        [NotMapped]
        [Compare("Admin_Password", ErrorMessage = "密碼不相符")]
        [Display(Name = "請再輸入一次密碼")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "請選擇{0}")]
        [Display(Name = "入職日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EntryDay { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "請輸入{0}")]
        [EmailAddress]
        [Display(Name = "信箱")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
    }
}
