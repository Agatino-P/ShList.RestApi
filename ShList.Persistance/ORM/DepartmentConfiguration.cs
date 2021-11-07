using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShList.Domain.Models;
using System;

namespace ShList.Persistance.ORM
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Name);
            builder.Property(b => b.Name).HasMaxLength(50); 

        }
    }
}