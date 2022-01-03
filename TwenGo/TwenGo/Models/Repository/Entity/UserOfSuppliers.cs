using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TwenGo.Models.Repository.Entity
{
    public class UserOfSuppliers
    {
        [Key,ForeignKey("Users")]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "企業名稱")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "統一編號")]
        public string TaxIDNumber { get; set; }

        [Required]
        [Display(Name = "實收資本額")]
        public string Capital { get; set; }

        public virtual Users Users { get; set; }
    }
}
