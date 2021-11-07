using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShList.Domain.Models;
using System;

namespace ShList.Persistance.ORM
{
    public class ShItemConfiguration : IEntityTypeConfiguration<ShItem>
    {
        public void Configure(EntityTypeBuilder<ShItem> builder)
        {
            builder.HasKey(shi => shi.Id);
            builder.Property(shi => shi.Product).HasMaxLength(50);
            builder.Property(shi => shi.Department).HasMaxLength(50);
            builder.Property(shi => shi.Shop).HasMaxLength(50);
        }
    }
}