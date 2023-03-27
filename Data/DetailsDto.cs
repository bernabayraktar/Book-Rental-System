using BorrowingABook.Models;

namespace BorrowingABook.Data
{
    public class DetailsDto
    {
        public Book Book { get; set; }
        public string PersonName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime BorrowingDtae { get; set; }
    }
}
