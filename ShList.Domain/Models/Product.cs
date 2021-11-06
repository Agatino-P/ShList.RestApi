using Ap.DDD.Models;
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
            SetName(name);
            SetDepartment(department);
        }

        
        public void SetName(string name)
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
    } 
}
