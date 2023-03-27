using BorrowingABook.Models;

namespace BorrowingABook.Data
{
    public interface IBorrow
    {
        Borrow GetLastBorrow(int id);
        void BarrowTheBook(Borrow borrow);  // if the book availability is CheckIn...
        void DeliverTheBook(int id); // book availability will be CheckIn and DeliveryDate will be the current date ☺
        Borrow GetBorrowInfo(int id);
 
    }
}
