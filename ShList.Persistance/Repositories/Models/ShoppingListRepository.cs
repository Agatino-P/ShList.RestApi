using Ap.DDD.Interfaces;
using Microsoft.EntityFrameworkCore;
using ShList.Domain.Models;
using ShList.Dto;
using ShList.Persistance.ORM;
using ShList.Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShList.Persistance.Repositories.Models
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly ShListContext _context;

        public ShoppingListRepository(ShListContext context)
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
            
            //_context.ShoppingLists.Attach(shoppingList);
            _context.Update(shoppingList);
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
            return _context.ShoppingLists.Include("_items").ToList();
        }

        public ShoppingList GetById(Guid id)
        {
            return _context.ShoppingLists.Include("_items").FirstOrDefault(sl=>sl.Id==id);
        }

        public void Delete(Guid id)
        {
            ShoppingList shoppingList = _context.ShoppingLists.Find(id);

            if (shoppingList != null)
            {
            _context.ShoppingLists.Remove(shoppingList);
            _context.SaveChanges();
            }
        }

    }
}
