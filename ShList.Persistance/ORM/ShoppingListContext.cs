using Microsoft.EntityFrameworkCore;
using ShList.Domain.Models;
using System;
using System.IO;

namespace ShList.Persistance.ORM
{
    public class ShoppingListContext : DbContext
    {
        private readonly string _connectionString;


        public DbSet<Product> Products { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Shop> Shops { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public ShoppingListContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShoppingListConfiguration());
            //modelBuilder.ApplyConfiguration(new ShItemConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
