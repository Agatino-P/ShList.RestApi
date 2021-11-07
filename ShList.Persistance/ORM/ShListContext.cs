using Microsoft.EntityFrameworkCore;
using ShList.Domain.Models;
using System;
using System.IO;

namespace ShList.Persistance.ORM
{
    public class ShListContext : DbContext
    {
        private readonly string _connectionString;


        public DbSet<Product> Products { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Shop> Shops { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public ShListContext(DbContextOptions<ShListContext> contextOptions) : base(contextOptions)
        {

        }
        //public ShListContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingListConfiguration());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
    }
}
