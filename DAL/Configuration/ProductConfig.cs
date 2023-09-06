using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Categorys).WithMany(x=>x.Products).HasForeignKey(x=>x.CategoryId);
            builder.HasOne(x=>x.Brands).WithMany(x=>x.Products).HasForeignKey(x=>x.BrandId);
        }
    }
}
