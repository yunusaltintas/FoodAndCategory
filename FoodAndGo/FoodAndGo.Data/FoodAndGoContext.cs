using FoodAndGo.Data.Entities;
using FoodAndGo.Data.EntityTypeBuilder;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAndGo.Data
{
    public class FoodAndGoContext : DbContext
    {
        public FoodAndGoContext(DbContextOptions options) : base(options)
        {

        }

        public FoodAndGoContext()
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Login> Logins { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new FoodEntityTypeBuilder())
                        .ApplyConfiguration(new LoginEntitytTypeBuilder())
                        .ApplyConfiguration(new CategoryEntityTypebuilder());

            base.OnModelCreating(modelBuilder);

        }


    }
}
