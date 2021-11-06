using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShList.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Departments : ControllerBase
    {
        // GET: api/<Departments>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Fruit", "Vegetables", "Meat", "Cans", "Fish", "Pasta", "Drinks", "Water" };
        }

        // GET api/<Departments>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Departments>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Departments>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Departments>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
