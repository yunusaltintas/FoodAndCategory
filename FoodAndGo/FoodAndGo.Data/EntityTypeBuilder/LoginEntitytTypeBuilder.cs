using FoodAndGo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAndGo.Data.EntityTypeBuilder
{
    public class LoginEntitytTypeBuilder : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.Property(p => p.UserName)
               .IsRequired()
               .HasMaxLength(120)
               .HasColumnType("varchar");

            builder.Property(p => p.Email)
               .IsRequired()
               .HasMaxLength(120)
               .HasColumnType("varchar");

            builder.Property(p => p.Password)
               .IsRequired()
               .HasMaxLength(350)
               .HasColumnType("varchar");

            builder.Property(p => p.Role)
               .IsRequired()
               .HasMaxLength(1)
               .HasColumnType("varchar");

        }
    }
}
