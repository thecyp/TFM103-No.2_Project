using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int Amount { get; set; }
        public int Subtotal { get; set; }
        public int Total { get; set; }
    }
}
