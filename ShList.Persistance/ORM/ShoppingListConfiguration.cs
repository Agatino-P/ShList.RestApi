using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShList.Domain.Models;

namespace ShList.Persistance.ORM
{
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {

        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            //builder.OwnsMany(typeof(ShItem), "_items",
            //    shi =>
            //    {
            //        shi.Property<int>("Id");
            //        shi.HasKey("Id");
            //        shi.WithOwner().HasForeignKey("ShListId");
            //        shi.Property("ShopId").IsRequired(false);
            //        shi.ToTable("ShItems");
            //    });
            //builder.Ignore("Items");
        }
    }
}