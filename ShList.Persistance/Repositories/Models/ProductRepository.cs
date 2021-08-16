using AP.DDD.Interfaces;
using ShList.Domain.Models;
using ShList.Persistance.ORM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShList.Persistance.Repositories.Models
{
    public class ProductRepository : IGuidRepository<Product>
    {
        private readonly ShoppingListContext _context;

        //public ProductRepository()
        //{

        //}
        public ProductRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(Guid id)
        {
            return _context.Products.Find(id);
        }
    }
}