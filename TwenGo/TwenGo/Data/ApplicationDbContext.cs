using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TwenGo.Models;

namespace TwenGo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
