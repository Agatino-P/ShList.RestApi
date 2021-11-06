using Ap.DDD.Models;
using ShList.Dto;

namespace ShList.Domain.Models
{
    public partial class ShItem : GuidEntity
    {
        public Product Product { get; private set; }
        public ShIQuantity Quantity { get; private set; }
        public ShItemStatus Status { get; private set; }
        public Department Department { get; private set; }
        public Shop Shop { get; private set; }


        private ShItem()
        {

        }

        public ShItem(Product product, ShIQuantity quantity, ShItemStatus status= ShItemStatus.Active)
        {
            Product = product;
            Quantity = quantity;
            Status = status;
        }

    }
}
