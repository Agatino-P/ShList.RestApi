using Ap.DDD.Interfaces;
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

        public ProductRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public Product Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Update(Product p)
        {
            _context.Products.Update(p);
            _context.SaveChanges();
        }

        public IReadOnlyCollection<Product> AddOrUpdate(IEnumerable<Product> products)
        {
            List<Product> retProducts = new List<Product>();
            
            foreach (Product p in products)
            {
                if (_context.Products.Find(p) != null)
                {
                    Update(p);
                    retProducts.Add(p);
                }
                else
                {
                    retProducts.Add(Add(p));
                }
            }
            return retProducts;
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(Guid id)
        {
            return _context.Products.Find(id);
        }

        public void Delete(Guid id)
        {
            _context.Products.Remove( _context.Products.Find(id));
            _context.SaveChanges();
        }
    }
}