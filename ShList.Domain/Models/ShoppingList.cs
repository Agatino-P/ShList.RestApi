using Ap.FunctionalProgramming;
using Ap.DDD.Models;
using System;
using System.Collections.Generic;

namespace ShList.Domain.Models
{
    public class ShoppingList : GuidEntity
    {
        public string Name { get; private set; }
        public DateTime DateTime { get; private set; }

        private List<ShItem> _items = new();
        public IList<ShItem> Items => _items.AsReadOnly();

        private ShoppingList() : base()
        {

        }
        public ShoppingList(string name, DateTime dateTime) : base()
        {
            Name = name;
            DateTime = dateTime;
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
    }
}
