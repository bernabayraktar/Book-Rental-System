using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowingABook.Models
{
    public class Borrow
    {
        [Key]
        public int Id { get; set; }

        

        [Required]
        public string PersonName { get; set; }

        [Required]
        public string TCKNO { get; set; }

        [Required]
        public string Tel { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        public DateTime BorrowingDate { get; set; } = DateTime.Today;


        [Required]
        public DateTime ExpectedDate { get; set; } = DateTime.Today.AddDays(21);

        public DateTime DeliveryDate { get; set; }

        [Required]
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
