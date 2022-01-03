using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwenGo.Models.Repository.Entity
{
    public class UserOfCustomer
    {
        [Key,ForeignKey("Users")]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "性別")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }

        [Display(Name = "大頭貼")]
        public string CustomerPicture { get; set; }

        public virtual Users Users { get; set; }
    }
}
