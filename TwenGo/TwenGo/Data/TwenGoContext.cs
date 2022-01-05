using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwenGo.Models;

namespace TwenGo.Data
{
    public class TwenGoContext : DbContext
    {
        public TwenGoContext (DbContextOptions<TwenGoContext> options)
            : base(options)
        {
        }

        public DbSet<TwenGo.Models.Product> Product { get; set; }
    }
}
