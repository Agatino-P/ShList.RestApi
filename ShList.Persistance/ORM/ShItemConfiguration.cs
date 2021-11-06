using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShList.Domain.Models;

namespace ShList.Persistance.ORM
{

    public class ShItemConfiguration : IEntityTypeConfiguration<ShItem>
    {
        public void Configure(EntityTypeBuilder<ShItem> builder)
        {
            builder.OwnsOne(shi => shi.Quantity);
        }
    }
}
