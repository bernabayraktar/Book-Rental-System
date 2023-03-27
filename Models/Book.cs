using BorrowingABook.Data;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BorrowingABook.Models
{
    public class Book
    {
        // string input = "ISBN-13: 978-0590353403";
        // bool isValid = Regex.IsMatch(input, @"^(?:ISBN(?:-1[03])?:? )?(?=[0-9X]{10}$|(?=(?:[0-9]+[- ]){3})[- 0-9X]{13}$)[0-9]{1,5}[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9X]$");
        //Console.WriteLine(isValid); // Outputs "True"

        //string regex = "^(?:ISBN(?:-1[03])?:? )?(?=[0-9X]{10}$|(?=(?:[0-9]+[- ]){3})[- 0-9X]{13}$)[0-9]{1,5}[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9X]$\r\n";

        public enum BookAvailability
        {
            CheckIn,
            CheckOut

        };

        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^(?:ISBN(?:-1[03])?:? )?(?=[0-9X]{10}$|(?=(?:[0-9]+[- ]){3})[- 0-9X]{13}$)[0-9]{1,5}[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9X]$
")]
        public string ISBN { get; set; }

        [Required]
        public string PublicationYear { get; set; }

        [Required]
        public int Price { get; set; }

        public BookAvailability Availability { get; set; }  // CheckIn or CheckOut?
    }
}
