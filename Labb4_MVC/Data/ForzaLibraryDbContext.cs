using Labb4_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4_MVC.Data
{
    public class ForzaLibraryDbContext : DbContext
    {
        public ForzaLibraryDbContext(DbContextOptions<ForzaLibraryDbContext> options) 
            : base(options) 
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookList> BooksLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
