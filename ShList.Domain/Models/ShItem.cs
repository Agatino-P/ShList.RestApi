using Ap.DDD.Models;
using System.Collections.Generic;

namespace ShList.Domain.Models
{
    public class ShItem : ValueObject
    {
        public Product Product { get; private set; }
        public Shop Shop { get; private set; }
        public int Quantity { get; private set; }

        private ShItem()
        {

        }

        public ShItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Product;
            yield return Shop;
            yield return Quantity;
        }
    }
}
