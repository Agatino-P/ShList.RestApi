using Ap.DDD.Interfaces;
using ShList.Domain.Models;
using ShList.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShList.Persistance.Repositories.Interfaces
{
    public interface IShoppingListRepository : IGuidRepository<ShoppingList>
    {
    }
}
