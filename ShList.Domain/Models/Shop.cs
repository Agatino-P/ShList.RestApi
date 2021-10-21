using Ap.DDD.Models;

namespace ShList.Domain.Models
{
    public class Shop : GuidEntity
    {
        public string Name { get; private set; }

        private Shop() : base()
        {
        }

        public Shop(string name) : this()
        {
            Name = name;
        }
    }
}
