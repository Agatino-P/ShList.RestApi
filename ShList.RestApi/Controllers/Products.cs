using Microsoft.AspNetCore.Mvc;
using ShList.Dto;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShList.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        // GET: api/<Products>
        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            return new List<ProductDto>()
            {
                new ProductDto(Guid.NewGuid(),"P1","D1"),
                new ProductDto(Guid.NewGuid(), "P2", "D2")
            };
        }

        // GET api/<Products>/5
        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(Guid id)
        {
            return Ok(new ProductDto(id, "id1", "desc1"));
        }

        // POST api/<Products>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Products>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Products>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
