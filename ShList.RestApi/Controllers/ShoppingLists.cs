using Ap.DDD.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ShList.Domain.Models;
using ShList.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShList.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingLists : ControllerBase
    {

        private readonly IGuidRepository<ShoppingList> _repository;

        private ShoppingList _shoppingList = new("TestShl", DateTime.Now);
        public ShoppingLists(IGuidRepository<ShoppingList> repository)
        {
            _repository = repository;

            //Product product = new("productTest", "departmentTest");
            //ShItem.ShIQuantity quantity = new(3);
            //ShItem item = new ShItem(product, null, null, quantity);
            //_shoppingList.Add(item);
            //repository.Add(_shoppingList);
        }

        // GET: api/<ShoppingListController>
        [HttpGet]
        public IEnumerable<ShoppingListDto> Get()
        {
            IReadOnlyCollection<ShoppingList> lists = _repository.GetAll();
            return lists.Select(shl => shl.ToDto());
        }

        // GET api/<ShoppingListController>/5
        [HttpGet("{id}")]
        public ShoppingListDto Get(Guid id)
        {
            ShoppingList sl = _repository.GetById(id);
            return sl.ToDto();
        }

        // POST api/<ShoppingListController>
        [HttpPost]
        public void Post([FromBody] ShoppingListDto dto)
        {
            ShoppingList shl = _repository.GetById(dto.Id);

            if (shl == null)
            {
                shl = new ShoppingList(dto.Name, dto.Created);
                if (dto.Items != null)
                {
                    shl.SetItems(dto.Items.Select(i => new ShItem(i)));
                }
                _repository.Add(shl);
            }
            else
            {
                _repository.Delete(shl.Id);
                shl.ClearItems();
                if (dto.Items != null)
                {
                    shl.SetItems(dto.Items.Select(i => new ShItem(i)));
                }
                _repository.Add(shl);
            }
        }

        // PUT api/<ShoppingListController>/5
        [HttpPut("{id}")]
        public void Put(int id/*, [FromBody] string value*/)
        {
            _repository.Add(_shoppingList);
            //_repository
        }

        // DELETE api/<ShoppingListController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}
