using Ap.DDD.Interfaces;
using ShList.Domain.Models;
using ShList.Persistance.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShList.Persistance.Repositories.Models
{
    public class ShoppingListRepository : IGuidRepository<ShoppingList>
    {
        private readonly ShoppingListContext _context;

        public ShoppingListRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public ShoppingList Add(ShoppingList ShoppingList)
        {
            _context.ShoppingLists.Add(ShoppingList);
            _context.SaveChanges();
            return ShoppingList;
        }

        public void Update(ShoppingList shoppingList)
        {
            _context.ShoppingLists.Update(shoppingList);
            _context.SaveChanges();
        }

        public IReadOnlyCollection<ShoppingList> AddOrUpdate(IEnumerable<ShoppingList> ShoppingLists)
        {
            List<ShoppingList> retShoppingLists = new List<ShoppingList>();

            foreach (ShoppingList shoppingList in ShoppingLists)
            {
                if (_context.ShoppingLists.Find(shoppingList) != null)
                {
                    Update(shoppingList);
                    retShoppingLists.Add(shoppingList);
                }
                else
                {
                    retShoppingLists.Add(Add(shoppingList));
                }
            }
            return retShoppingLists;
        }

        public IReadOnlyCollection<ShoppingList> GetAll()
        {
            return _context.ShoppingLists.ToList();
        }

        public ShoppingList GetById(Guid id)
        {
            return _context.ShoppingLists.Find(id);
        }

        public void Delete(Guid id)
        {
            _context.ShoppingLists.Remove(_context.ShoppingLists.Find(id));
            _context.SaveChanges();
        }
    }
}
