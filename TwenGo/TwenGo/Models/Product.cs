using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String ProductName { get; set; }
        public String Address { get; set; }//0110改

        [MaxLength(100)]
        public String Description { get; set; }
        public int Price { get; set; }
        public String PicturePath { get; set; }
    }
}
