using System;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.DAL;

namespace BookStoreApp.Data
{
    public class EFBookContext : DbContext
    {
        public EFBookContext(DbContextOptions<EFBookContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<Scanner> Scanners { get; set; }
    }
}
