using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.ViewModels;

namespace TwenGo.Models
{
    public class TwenGoContext:DbContext
    {
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }

        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public TwenGoContext(DbContextOptions<TwenGoContext> options)
         : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("TwenGoContextConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");
            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");
                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasColumnName("Message");
            });

        }
        public DbSet<TwenGo.ViewModels.CustomerViewModel> CustomerViewModel { get; set; }
    }
}

