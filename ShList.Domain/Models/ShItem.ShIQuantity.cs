using Ap.DDD.Models;
using ShList.Dto;
using System;
using System.Collections.Generic;

namespace ShList.Domain.Models
{
    public partial class ShItem
    {
        public class ShIQuantity : ValueObject
        {
            private ShIQuantity() : this(0)
            {
            }

            public ShIQuantity(int quantity)
            {
                if (quantity < 0)
                {
                    throw new System.Exception("Negative Shopping Item Quantity");
                }
                this.quantity = quantity;
            }

            private int quantity { get; set; }
            
            public static implicit operator int (ShIQuantity shiQuantity) => shiQuantity.quantity;

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return quantity;
            }
        }

        internal ShItemDto ToDto()
        {
            return new ShItemDto(Product, Department, Shop, Quantity, Status.ToString());
        }
    }
}
