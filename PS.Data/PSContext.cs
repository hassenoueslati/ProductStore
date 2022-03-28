using Microsoft.EntityFrameworkCore;
using PS.Data.MyConfigurations;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data
{
    public class PSContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<Biological> Biologicals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=ProductStoreDB;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.Entity<Category>().ToTable("MyCategories");
            modelBuilder.Entity<Category>().HasKey(C => C.CategoryId);
            modelBuilder.Entity<Category>().Property(C => C.Name).IsRequired().HasMaxLength(50);
           
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
