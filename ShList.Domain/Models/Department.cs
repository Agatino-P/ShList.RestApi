using Ap.DDD.Models;

namespace ShList.Domain.Models
{
    public class Department : GuidEntity
    {
        private Department() : base()
        {
        }
        public Department(string name) : base()
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
