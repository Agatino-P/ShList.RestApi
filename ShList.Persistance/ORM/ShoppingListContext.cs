using Microsoft.EntityFrameworkCore;
using ShList.Domain.Models;

namespace ShList.Persistance.ORM
{
    public class ShoppingListContext : DbContext
    {
        private readonly string _connectionString;

        //private readonly string _connectionString;

        public DbSet<Product> Products { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Shop> Shops { get; set; }
        //public DbSet<ShoppingList> ShLists { get; set; }

        public ShoppingListContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        //public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShoppingListConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        //    string SqliteDbPath = @"d:\Git Local Repository\ShList\db\ShoppingList.db";
        //    string SqliteConnectionString = $"Data Source=file:{SqliteDbPath}";
            optionsBuilder.UseSqlite(_connectionString);
        }
    }
}
