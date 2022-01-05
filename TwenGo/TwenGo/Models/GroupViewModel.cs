using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class GroupViewModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupID { get; set; }
        //public String ProductName { get; set; }
        //public String Quantity { get; set; }

        //public decimal Price { get; set; }
        public DateTime GroupTime { get; set; }
        public DateTime UpdateTime { get; set; }

        //[ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
    }
}
