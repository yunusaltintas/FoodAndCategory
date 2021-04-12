using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAndGo.Data.EntityTypeBuilder
{
    public class FoodEntityTypeBuilder : IEntityTypeConfiguration<Food>
    {


        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(p => p.FoodName)
                .IsRequired()
                .HasMaxLength(120)
                .HasColumnType("varchar");
           
            builder.Property(p => p.FoodDescp)
                .IsRequired()
                .HasMaxLength(250)
                 .HasColumnType("varchar");

            builder.Property(p => p.Price)
               .IsRequired();
            builder.Property(p => p.Stock)
                .IsRequired();
               
        }
    }
}
