using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models.ViewModels
{
    public class LoginViewModel
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "請輸入{0}")]
        [EmailAddress]
        [Display(Name = "信箱")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [MaxLength(30)]
        [DataType(DataType.Password)]//默認生成的是密碼框而不是文字框
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [Display(Name = "記住我")]
        public bool RememberMe { get; set; }
    }
}
