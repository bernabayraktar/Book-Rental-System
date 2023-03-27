using BorrowingABook.Models;
using Microsoft.EntityFrameworkCore;

namespace BorrowingABook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
    }
}
