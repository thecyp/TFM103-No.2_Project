using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwenGo.Models.Repository.Entity
{
    public class Users : IdentityUser
    {

        [Display(Name = "姓名")]
        public string RealName { get; set; }


        [Display(Name = "身分證字號")]
        public string IdentityNumber { get; set; }

                
        [Display(Name = "城市")]
        public string City { get; set; }

       
        [Display(Name = "區域")]
        public string Town { get; set; }

        
        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "記住我?")]
        public bool RememberMe { get; set; }

        public virtual UserOfAdmin UserOfAdmin { get; set; }       
        public virtual UserOfCustomer UserOfCustomer { get; set; }
    }
}
