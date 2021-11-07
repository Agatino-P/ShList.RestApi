using Ap.FunctionalProgramming;
using Ap.DDD.Models;
using System;
using System.Collections.Generic;
using ShList.Dto;
using System.Linq;

namespace ShList.Domain.Models
{
    public class ShoppingList : GuidEntity
    {
        public string Name { get; private set; }
        public DateTime Created { get; private set; }

        private List<ShItem> _items = new();
        public IList<ShItem> Items => _items.AsReadOnly();

        private ShoppingList() : base()
        {

        }
        public ShoppingList(string name, DateTime created) : base()
        {
            Name = name;
            Created = created;
        }


        public Result<ShItem> Add(ShItem shItem)
        {
            if (_items.Contains(shItem))
            {
                return Result<ShItem>.Fail(shItem, "Item already present");
            }

            if (!Items.Contains(shItem))
            {
                _items.Add(shItem);
            }

            return Result<ShItem>.Ok(shItem);
        }

        public ShoppingListDto ToDto()
        {
            ShoppingListDto retval = new ShoppingListDto(
                Id, Name, Created, Items.Select(i => i.ToDto())
                );
            return retval;
        }

        public void ClearItems()
        {
            _items.Clear();
        }

        public void SetItems(IEnumerable<ShItem> items)
        {
            _items = new List<ShItem>(items);  
        }
    }
}
