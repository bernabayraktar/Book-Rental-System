using BorrowingABook.Models;

namespace BorrowingABook.Data
{
    public class BorrowRepo : IBorrow

    {
        private readonly ApplicationDbContext _context;

        public BorrowRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void BarrowTheBook(Borrow borrow)
        {
            //kitap ödünç alma işlemi =) kitap durumu---> checkout 

            var book = _context.Books.FirstOrDefault(x => x.BookId == borrow.BookId);
            if (book != null && (int)book.Availability == 0)
            {
                borrow.Title = book.Title;
                book.Availability = Book.BookAvailability.CheckOut;
                _context.Books.Update(book);
                _context.Add(borrow);
                _context.SaveChanges();
            }
        }

        public void DeliverTheBook(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.BookId == id);
            if (book != null && (int)book.Availability == 1)
            {
                var lastBorrow = _context.Borrows
               .Where(b => b.BookId == id && b.DeliveryDate == new DateTime(0001, 1, 1))
               .OrderByDescending(b => b.BorrowingDate)
               .FirstOrDefault();

                lastBorrow.DeliveryDate = DateTime.Now;
                _context.Update(lastBorrow);
                book.Availability = Book.BookAvailability.CheckIn;
                _context.Books.Update(book);
                _context.SaveChanges();
            }
        }
        public Borrow GetLastBorrow(int id)
        {
            var lastBorrow = _context.Borrows
               .Where(b => b.BookId == id && b.DeliveryDate == new DateTime(0001, 1, 1))
               .OrderByDescending(b => b.BorrowingDate)
               .FirstOrDefault();

            return lastBorrow;
        }

        public Borrow GetBorrowInfo(int id)
        {
            var lastBarrow = _context.Borrows
                .Where(b => b.BookId == id)
                .OrderByDescending(b => b.BorrowingDate)
                .FirstOrDefault();

            return lastBarrow;
        }


    }
}
