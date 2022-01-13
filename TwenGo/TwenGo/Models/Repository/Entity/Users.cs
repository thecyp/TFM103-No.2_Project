using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TwenGo.Models.Repository.Entity
{
    public class Users : IdentityUser
    {
        [Required]
        [Display(Name = "姓名")]
        public string RealName { get; set; }

        [Required]
        [Display(Name = "身分證字號")]
        public string IdentityNumber { get; set; }

        

        [Required]
        [Display(Name = "城市")]
        public string City { get; set; }

        [Required]
        [Display(Name = "區域")]
        public string Town { get; set; }

        [Required]
        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "記住我?")]
        public bool RememberMe { get; set; }

        public virtual UserOfAdmin UserOfAdmin { get; set; }       
        public virtual UserOfCustomer UserOfCustomer { get; set; }
    }
}
