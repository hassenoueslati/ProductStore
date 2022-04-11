using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.MyConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Config relation * *
            builder.HasMany(p => p.Providers).WithMany(pr => pr.Products)
                .UsingEntity(t => t.ToTable("Providings"));
            //Config relation 0/1 *
            builder.HasOne(p => p.Category).WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryFK)
                .OnDelete(DeleteBehavior.Cascade);
            //Config relation 1/1 *
            //builder.HasOne(p => p.Category).WithMany(c => c.Products)
            //    .HasForeignKey(p => p.CategoryFK)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
