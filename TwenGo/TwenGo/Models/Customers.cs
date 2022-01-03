using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class Customers
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "買家編號")]
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "姓名")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "信箱")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "密碼")]
        public string C_Password { get; set; }

        [Required]
        [Display(Name = "性別")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }

        [Required]
        [Display(Name = "身分證字號")]
        public string IdentityNumber { get; set; }

        

        [Required]
        [Display(Name = "手機號碼")]
        public string CellPhone { get; set; }

        [Display(Name = "電話號碼")]
        public string Phone { get; set; }

        

        [Required]
        [Display(Name = "城市")]
        public string City { get; set; }

        [Required]
        [Display(Name = "區域")]
        public string Town { get; set; }

        [Required]
        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "大頭貼")]
        public string CustomerPicture { get; set; }

                    
        
    }
}
