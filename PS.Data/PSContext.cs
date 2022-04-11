using Microsoft.EntityFrameworkCore;
using PS.Data.MyConfigurations;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.Entity<Category>().ToTable("MyCategories");
            modelBuilder.Entity<Category>().HasKey(C => C.CategoryId);
            modelBuilder.Entity<Category>().Property(C => C.Name).IsRequired().HasMaxLength(50);
           
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //configuré l'heritage TPH
            //modelBuilder.Entity<Product>()
            //    .HasDiscriminator<int>("IsBiological")
            //    .HasValue<Product>(2)
            //    .HasValue<Biological>(1)
            //    .HasValue<Chemical>(0);

            //Configuré l'heritage TPT
            modelBuilder.Entity<Chemical>().ToTable("Chemicals");
            modelBuilder.Entity<Biological>().ToTable("Biologicals");

            //définir une configuration pour tous le model par rapport le nom de l'attribut Name
            foreach (var prop in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.ClrType == typeof(String) && p.Name.StartsWith("Name"))
                )
            {
                prop.SetColumnName("MyName");
            }

            //définir une configuration pour mapper tous les props qui finissent par code dans des columns obligatoire
            foreach (var prop in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.Name.EndsWith("code"))
                )
            {
                prop.IsNullable = false;
            }

            //Table Proteuse config FK

            modelBuilder.Entity<Achat>().HasKey(a => new { a.DateAchat, a.ClientFK, a.ProductFK });
            base.OnModelCreating(modelBuilder);


        }
    }
}
