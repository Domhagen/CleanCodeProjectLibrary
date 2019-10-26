using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using IDataInterface;

namespace DataAccess
{
    public class LibraryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI;Database=Library;Trusted_connection=true");
        }
        public DbSet<Aisle> Ailes { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
