using Ap.DDD.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ShList.Domain.Models;
using System;
using System.Collections.Generic;

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
            Product product = new("productTest", "departmentTest");
            ShItem.ShIQuantity quantity = new(3);
            ShItem item = new ShItem(product, null,null, quantity);
            _shoppingList.Add(item);

        }

        // GET: api/<ShoppingListController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ShoppingListController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShoppingListController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
        public void Delete(int id)
        {
        }
    }
}
