using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAndGo.Data.EntityTypeBuilder
{
    public class BaseEntityTypeBuilder<T> where T : BaseEntity,IEntityTypeConfiguration<BaseEntity>
    {

        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn(1,1);


            
        }


    }
    
}
