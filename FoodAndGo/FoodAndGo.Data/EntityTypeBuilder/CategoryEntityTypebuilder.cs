using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAndGo.Data.EntityTypeBuilder
{
    public class CategoryEntityTypebuilder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasMany(i => i.Foods).WithOne(i => i.Category).HasForeignKey(i => i.CategoryId);
            builder.Property(p => p.CategoryName)
                .IsRequired()
                .HasMaxLength(120)
                 .HasColumnType("varchar");


            builder.Property(p => p.CategoryDescp)
                .IsRequired()
                .HasMaxLength(250)
                 .HasColumnType("varchar");




        }
    }
}
