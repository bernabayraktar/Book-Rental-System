using BorrowingABook.Models;

namespace BorrowingABook.Data
{
    public class BookRepo : IBook
    {
        private readonly ApplicationDbContext _context;
        public BookRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Where(b => b.BookId == id).FirstOrDefault();
        }
    }
}
