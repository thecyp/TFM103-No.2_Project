using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Data
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupID { get; set; }
        public DateTime GroupDate { get; set; }
        public DateTime CountDown { get; set; }

        [ForeignKey("ProductID")]
        public int ProductID { get; set; }

    }
}
