using AP.DDD.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        //public Product Add(Product product)
        //{
        //    _context.Products.Add(product);
        //    _context.SaveChanges();
        //    return product;
        //}

        public Product Add(Product product)
        {
            _context.Products.Add(new Product(product.Name, product.Notes));
            _context.SaveChanges();
            return product;
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(Guid id)
        {
            return _context.Products.Find(id);
        }

        public void Update(Product p)
        {
            _context.Products.Update(p);
            _context.SaveChanges();
        }
    }
}