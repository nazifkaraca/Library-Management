using Library.DAL.Entities;
using Library.Services;
using Library.Views.ViewComponents;
using Library.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
    /// <summary>
    /// Controller to manage book-related operations.
    /// </summary>
    public class BookController : Controller
    {
        /// <summary>
        /// Dependency injection of the book service.
        /// </summary>
        private readonly IBookService _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class.
        /// </summary>
        /// <param name="context">Book service for data operations.</param>
        public BookController(IBookService context)
        {
            _context = context;
        }

        /// <summary>
        /// GET call for updating a book.
        /// </summary>
        /// <param name="id">ID of the book to update.</param>
        /// <returns>View containing book information and a list of authors.</returns>
        [HttpGet]
        public IActionResult UpdateBook(int id)
        {
            var book = _context.GetBookById(id); // Retrieve book by ID
            if (book == null)
            {
                return NotFound(); // Return 404 if book not found
            }

            var authors = _context.GetAuthors(); // Retrieve author list

            // Prepare view model
            var model = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                AuthorId = book.AuthorId,
                CopiesAvailable = book.CopiesAvailable,
                Authors = authors.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Id + " | " + a.FirstName + " " + a.LastName,
                    Selected = a.Id == book.AuthorId
                }).ToList()
            };

            return View(model);
        }

        /// <summary>
        /// POST call for updating a book.
        /// </summary>
        /// <param name="book">Updated book entity.</param>
        /// <returns>Redirects to the books section.</returns>
        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            _context.BookUpdate(book); // Update book in the database
            return Redirect("/#books"); // Redirect to books section
        }

        /// <summary>
        /// GET call for creating a new book.
        /// </summary>
        /// <returns>View with a list of authors for book creation.</returns>
        [HttpGet]
        public IActionResult CreateBook()
        {
            var authors = _context.GetAuthors();

            var model = new BookViewModel
            {
                Authors = authors.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Id + " | " + a.FirstName + " " + a.LastName
                }).ToList()
            };

            return View(model);
        }

        /// <summary>
        /// POST call for creating a new book.
        /// </summary>
        /// <param name="book">Book entity to create.</param>
        /// <returns>
        /// Returns to the same view with validation errors if the model is invalid,
        /// or redirects to the books section on success.
        /// </returns>
        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            if (!ModelState.IsValid) // Validate the model
            {
                return View(book);
            }

            _context.BookCreate(book); // Add the new book
            ModelState.Clear(); // Clear the model state
            return Redirect("/#books"); // Redirect to books section
        }

        /// <summary>
        /// Deletes a book by ID.
        /// </summary>
        /// <param name="id">ID of the book to delete.</param>
        /// <returns>Redirects to the books section.</returns>
        public IActionResult DeleteBook(int id)
        {
            var book = _context.GetBookById(id);
            if (book == null)
            {
                return NotFound(); // Return 404 if book not found
            }

            _context.BookDelete(id); // Delete the book
            return Redirect("/#books"); // Redirect to books section
        }

        /// <summary>
        /// GET call for retrieving book details.
        /// </summary>
        /// <param name="id">ID of the book to view details.</param>
        /// <returns>View containing book details.</returns>
        [HttpGet]
        public IActionResult DetailBook(int id)
        {
            var books = _context.GetBookById(id); // Retrieve book by ID
            return View(books);
        }

        /// <summary>
        /// Retrieves a list of all books.
        /// </summary>
        /// <returns>View containing the list of books.</returns>
        public IActionResult Index()
        {
            var books = _context.GetBooks(); // Retrieve all books
            return View(books);
        }
    }
}
