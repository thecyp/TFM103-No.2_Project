using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Data;
using TwenGo.Models;
using TwenGo.Models.Repository.Entity;

namespace TwenGo.Models.Repository
{
    public class TwenGoContext : IdentityDbContext<Users>
    {
        public virtual DbSet<UserOfSuppliers> UserOfSuppliers { get; set; }
        public virtual DbSet<UserOfCustomer> UserOfCustomer { get; set; }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<Category> Categories { get; set; }

        public  DbSet<Group> Groups { get; set; }
        public TwenGoContext(DbContextOptions<TwenGoContext> options)
         : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Shipper> Shippers { get; set; }
    }
}
