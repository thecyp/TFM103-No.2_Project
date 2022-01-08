using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TwenGo.Models.Repository.Entity
{
    public class TwenGoRole
    {
        [Key, ForeignKey("Users")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "角色")]
        public string RoleName { get; set; }

        public virtual Users Users { get; set; }
    }
}
