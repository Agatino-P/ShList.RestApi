using Ap.DDD.Models;
using System.Collections.Generic;

namespace ShList.Domain.Models
{
    public class Department : ValueObject
    {
        private Department() : base()
        {
        }
        public Department(string name) : base()
        {
            Name = name;
        }

        public string Name { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
