using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TwenGo.Models.Repository.Entity
{
    public class Roles
    {
        [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
       public string RoleName { get; set; }

        
    }
}
