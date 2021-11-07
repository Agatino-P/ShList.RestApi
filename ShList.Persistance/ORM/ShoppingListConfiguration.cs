using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShList.Domain.Models;
using System;

namespace ShList.Persistance.ORM
{
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {

        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.HasKey(shl => shl.Id);
            builder.HasMany<ShItem>("_items")
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Ignore("Items");

            //builder.Property(p => p.Name).HasColumnType("varchar(50)");

        }
    }
}