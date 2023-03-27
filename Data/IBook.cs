using BorrowingABook.Models;

namespace BorrowingABook.Data
{
    public interface IBook 
    {
        List<Book> GetAll();
        Book GetById(int id);
    }
}
