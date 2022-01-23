using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spgateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TwenGo.Data;
using TwenGo.Models;
using TwenGo.Models.Repository.Entity;
using TwenGo.Models.ViewModels;

namespace TwenGo.Models.Repository
{
    public class TwenGoContext : IdentityDbContext<Users>
    {
        public virtual DbSet<UserOfAdmin> UserOfAdmin { get; set; }
        public virtual DbSet<UserOfCustomer> UserOfCustomer { get; set; }

        public override DbSet<Users> Users { get; set; }
        
        public  DbSet<Product> Products { get; set; }

        public  DbSet<Group> Groups { get; set; }
        public TwenGoContext(DbContextOptions<TwenGoContext> options)
         : base(options)
        {
        }

       
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<SpgatewayOutputDataModel> SpgatewayOutputDataModels { get; set; }

        
    }
}
