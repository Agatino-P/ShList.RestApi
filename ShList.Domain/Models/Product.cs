using Ap.DDD.Models;
using ShList.Dto;
using System;
using System.Collections.Generic;

namespace ShList.Domain.Models
{
    public class Product : ValueObject
    {
        public string Name { get; private set; }
        public string Department { get; private set; } = string.Empty;

        //for EF
        private Product() : base()
        {
        }

        public Product(string name) : this(name, string.Empty)
        { }
        
        public Product(string name, string department)
        { 
            setName(name);
            SetDepartment(department);
        }


        public Product(ProductDto dto) : this(dto.Name, dto.Department)
        {
        }

        private void setName(string name)
        {
            //add guard clause against null, empty is fine
            Name = name;
        }

        public void SetDepartment(string notes)
        {
            //add guard clause against null, empty is fine
            Department = notes;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Department;
        }

        public ProductDto ToDto() => new ProductDto(Name, Department);
    } 
}
