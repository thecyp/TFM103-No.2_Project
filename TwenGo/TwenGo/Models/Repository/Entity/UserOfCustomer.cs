using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwenGo.Models.Repository.Entity
{
    public class UserOfCustomer
    {
        [Key,ForeignKey("Users")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "性別")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }

        [Display(Name = "大頭貼")]
        public string CustomerPicture { get; set; }

        [Required]
        [Display(Name = "手機號碼")]
        public string CellPhone { get; set; }

        [Display(Name = "電話號碼")]
        public string Phone { get; set; }

        public virtual Users Users { get; set; }
    }
}
