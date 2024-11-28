using Library.DAL.Entities;
using Library.Services;
using Library.Views.ViewComponents;
using Library.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var book = _context.GetBookById(id); // Kitabı ID ile al

            if (book == null)
            {
                return NotFound(); // Kitap yoksa 404 döner
            }

            var authors = _context.GetAuthors(); // Yazar listesini al

            var model = new BookViewModel
            {
                Id = book.Id, // Kitap ID
                Title = book.Title, // Kitap Başlığı
                Genre = book.Genre, // Kitap Açıklaması
                PublishDate = book.PublishDate, // Kitap Açıklaması
                ISBN = book.ISBN, // Kitap Açıklaması
                AuthorId = book.AuthorId, // Seçili Yazar
                CopiesAvailable = book.CopiesAvailable, // Seçili Yazar
                Authors = authors.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(), // Yazar ID
                    Text = a.Id + " | " + a.FirstName + " " + a.LastName, // Yazar adı
                    Selected = a.Id == book.AuthorId // Mevcut yazar seçili
                }).ToList()
            };

            return View(model);
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
            var authors = _context.GetAuthors();

            var model = new BookViewModel
            {
                Authors = authors.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(), // AuthorId
                    Text = a.Id + " | " + a.FirstName + " " + a.LastName // Author'un adı
                }).ToList()
            };

            return View(model);
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

        [HttpGet]
        public IActionResult DetailBook(int id)
        {
            var books = _context.GetBookById(id);
            return View(books);
        }

        public IActionResult Index()
        {
            var books = _context.GetBooks(); // Retrieve all books
            return View(books);
        }
    }
}
