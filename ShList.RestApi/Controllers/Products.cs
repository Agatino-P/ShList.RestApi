﻿using Ap.DDD.Interfaces;
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
    public class Products : ControllerBase
    {
        private readonly IGuidRepository<Product> _repository;

        public Products(IGuidRepository<Product> repository)
        {
            _repository = repository;
        }

        // GET: api/<Products>
        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            IReadOnlyCollection<Product> products = _repository.GetAll();
            return products.Select(p => toDto(p));
        }

        // GET api/<Products>/5
        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(Guid id)
        {
            Product product = _repository.GetById(id);
            return Ok(toDto(product));
        }

        // POST api/<Products>
        [HttpPost]
        public ActionResult<ProductDto> Post([FromBody] ProductDto dto)
        {
            Product product = _repository.GetById(dto.Id);
            if (product == null)
            {
                product = toProduct(dto);
                _repository.Add(product);
            }
            else
            {
                product.SetName(dto.Name);
                product.SetNotes(dto.Notes);
                _repository.Update(product);
            }
            return Ok(toDto(product));
        }

        // DELETE api/<Products>/5
        [HttpDelete("{id}")]
        public ActionResult<ProductDto> Delete(Guid id)
        {
            Product product = _repository.GetById(id);
            _repository.Delete(id);
            return Ok(toDto(product));
        }

        private ProductDto toDto(Product product) => new ProductDto(product.Id, product.Name, product.Notes);

        private Product toProduct(ProductDto dto) => new Product(dto.Id, dto.Name, dto.Notes);


    }
}
