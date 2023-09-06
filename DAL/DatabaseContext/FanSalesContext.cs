using DAL.Configuration;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DatabaseContext
{
    public class FanSalesContext : DbContext
    {
        public FanSalesContext()
        {

        }

        public FanSalesContext(DbContextOptions<FanSalesContext> options) : base(options)
        {

        }



        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderDetailConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-5169M4OF\\SQLEXPRESS;Initial Catalog=TrainingAPI;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
