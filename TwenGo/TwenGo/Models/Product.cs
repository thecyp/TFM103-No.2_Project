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
        public int ProductID { get; set; }
        public String ProductName { get; set; }
        public String Quantity { get; set; }
        [MaxLength(100)]
        public String Description { get; set; }
        public decimal Price { get; set; }
        public String PicturePath { get; set; }

        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }

    }
}
