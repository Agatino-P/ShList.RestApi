using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShList.Domain.Models;
using System;

namespace ShList.Persistance.ORM
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Name);
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Department).HasMaxLength(50);
        }
    }
}