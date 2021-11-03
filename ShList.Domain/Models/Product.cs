using Ap.DDD.Models;
using System;

namespace ShList.Domain.Models
{
    public class Product : GuidEntity
    {
        public string Name { get; private set; }
        public string Notes { get; private set; } = string.Empty;

        //for EF
        private Product() : base()
        {
        }

        public Product(string name) : this(name, string.Empty)
        { }
        
        public Product(string name, string notes) : base()
        {
            SetName(name);
            SetNotes(notes);
        }

        public Product(Guid id, string name, string notes)
        {
            Id = id;
            SetName(name);
            SetNotes(notes);
        }

        public void SetName(string name)
        {
            //add guard clause against null, empty is fine
            Name = name;
        }

        public void SetNotes(string notes)
        {
            //add guard clause against null, empty is fine
            Notes = notes;
        }
    } 
}
