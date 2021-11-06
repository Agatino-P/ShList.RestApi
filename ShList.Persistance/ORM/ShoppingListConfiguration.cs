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
            builder.OwnsMany(typeof(ShItem), "_items");
            builder.Ignore("Items");
        }
    }
}