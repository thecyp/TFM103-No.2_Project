using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwenGo.Models.Repository.Entity
{
    public class UserOfAdmin
    {
        [Key,ForeignKey("Users")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AdminId { get; set; }

       
        [Required]
        public string JobTitle { get; set; }

        [Required]
        public DateTime EntryDay { get; set; }

        public virtual Users Users { get; set; }
    }
}
