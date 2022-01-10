using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models.Repository.Entity
{
    public class UserOfAdmin
    {
        [Key, ForeignKey("Users")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AdminId { get; set; }

        [Required]
        public string EmployeeName { get; set; }


        [Required]
        public string JobTitle { get; set; }

        [Required]
        public DateTime EntryDay { get; set; }

        
        public virtual Users Users { get; set; }
    }
}
