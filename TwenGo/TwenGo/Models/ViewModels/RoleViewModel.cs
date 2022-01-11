using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models.ViewModels
{
    public class RoleViewModel
    {
        [MaxLength(30)]
        [Display(Name = "角色名稱")]
        [Required(ErrorMessage = "請輸入{0}")]
        public string RoleName { get; set; }
    }
}
