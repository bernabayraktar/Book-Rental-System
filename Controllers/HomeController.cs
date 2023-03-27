using BorrowingABook.Data;
using BorrowingABook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace BorrowingABook.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookRepo bookRepo;
        private readonly BorrowRepo borrowRepo;

        public HomeController(BookRepo repo, BorrowRepo borrowRepo)
        {
            this.bookRepo = repo;
            this.borrowRepo = borrowRepo;
        }

        public IActionResult Index()
        {
            Console.WriteLine((int)Book.BookAvailability.CheckIn);
            Log.Info("Index sayfası açıldı");
            return View();
        }

        public IActionResult CheckIn(int id)
        {
            ViewBag.Id = id;
            var lastborrow = borrowRepo.GetLastBorrow(id);
            if (DateTime.Today > lastborrow.ExpectedDate)
            {
                TimeSpan delay = DateTime.Today - lastborrow.ExpectedDate;
                int delayDays = delay.Days;
                int penalty = delayDays * 5; // ceza miktarı hesaplanıyor
                ViewBag.Penalty = penalty; // View'da göstermek için ViewBag'e ceza miktarı atanıyor
            }
            else
            {
                ViewBag.Penalty = 0; // Beklenen tarihten erken teslim edildiyse ceza miktarı sıfır olarak atanıyor
            }

            return View(lastborrow);
        }

        [HttpPost]
        public IActionResult CheckInBook(int id)
        {
            borrowRepo.DeliverTheBook(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CheckOut(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(int id, [FromForm] Borrow borrow)
        {
            borrow.BookId = id;
            borrowRepo.BarrowTheBook(borrow);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Detail(int id)
        {
            var book = bookRepo.GetById(id);
            if (book == null) { return RedirectToAction("Index", "Home"); }
            DetailsDto detail = new DetailsDto();
            detail.Book = book;
            var lastBorrow = borrowRepo.GetBorrowInfo(id);
            if (lastBorrow != null)
            {
                detail.PersonName = lastBorrow.PersonName;
                detail.DeliveryDate = lastBorrow.DeliveryDate;
                detail.BorrowingDtae = lastBorrow.BorrowingDate;
            }
            return View(detail);
        }

        [HttpGet]
        [Route("/Home/library")]
        public IActionResult GetLibrary()
        {
            var books = bookRepo.GetAll();

            return Json(new { data = books });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}