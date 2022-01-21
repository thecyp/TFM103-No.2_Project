using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models
{
    public class LaunchViewModel
    {
        public String ProductName { get; set; }
        public String countyName { get; set; }
        public String districtName { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }
        //public String img { get; set; }
      
        public List<IFormFile> pic { get; set; }
        public List<IFormFile> img { get; set; }

    }
}
