using Library.DAL.Entities;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _context;

        public BookController(IBookService context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult UpdateBook(int id)
        {
            var book = _context.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            _context.BookUpdate(book);
            
            return Redirect("/#books"); // Redirect to the books section
        }


        [HttpGet]
        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            if (ModelState.IsValid) // Validate the model
            {
                return View(book);
            }

            _context.BookCreate(book); // Add the new book
            ModelState.Clear();
            return Redirect("/#books"); // Redirect to the books section
        }

        public IActionResult DeleteBook(int id)
        {
            var book = _context.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.BookDelete(id); // Delete the book
            return Redirect("/#books");
        }

        public IActionResult Index()
        {
            var books = _context.GetBooks(); // Retrieve all books
            return View(books);
        }
    }
}
