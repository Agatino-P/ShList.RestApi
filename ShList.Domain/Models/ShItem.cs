using Ap.DDD.Models;
using ShList.Dto;
using System;

namespace ShList.Domain.Models
{
    public partial class ShItem : GuidEntity
    {
        public string Product { get; private set; }
        public string Department{ get; private set; }
        public string Shop { get; private set; }
        public int  Quantity { get; private set; }
        public ShItemStatus Status { get; private set; }


        private ShItem()
        {

        }
        public ShItem(ShItemDto dto)
        {
            Product = dto.Product;
            Department = dto.Department; ;
            Shop = dto.Shop;
            Quantity = dto.Quantity;
            if (Enum.TryParse<ShItemStatus>(dto.Status, out ShItemStatus status))
            {
                Status = status;
            }
        }

        public ShItem(Product product, Department department = null, Shop shop = null, ShIQuantity quantity= null, ShItemStatus status= ShItemStatus.Active)
        {
            Product = product.Name;
            Department = department?.Name ?? product.Department; ;
            Shop = shop?.Name;
            Quantity = quantity;
            Status = status;
        }
    }
}
