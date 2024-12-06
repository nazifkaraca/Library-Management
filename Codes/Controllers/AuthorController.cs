using Library.DAL.Entities;
using Library.Services;
using Library.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Library.Controllers
{
    /// <summary>
    /// Controller for managing author-related operations.
    /// </summary>
    public class AuthorController : Controller
    {
        /// <summary>
        /// Dependency injection of the author service.
        /// </summary>
        private readonly IAuthorService _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorController"/> class.
        /// </summary>
        /// <param name="context">The author service for data operations.</param>
        public AuthorController(IAuthorService context)
        {
            _context = context;
        }

        /// <summary>
        /// GET call for updating an author.
        /// </summary>
        /// <param name="id">ID of the author to update.</param>
        /// <returns>View containing author information for update.</returns>
        [HttpGet]
        public IActionResult UpdateAuthor(int id)
        {
            var author = _context.GetAuthorById(id);

            if (author == null)
            {
                return NotFound(); // Return 404 if author not found
            }

            // Prepare view model for author
            var model = new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth
            };

            return View(model); // Send the author model to the view
        }

        /// <summary>
        /// POST call for updating an author.
        /// </summary>
        /// <param name="author">Author entity to update.</param>
        /// <returns>Redirects to the authors main page.</returns>
        [HttpPost]
        public IActionResult UpdateAuthor(Author author)
        {
            _context.AuthorUpdate(author); // Perform update
            return Redirect("/#authors"); // Redirect to authors main page
        }

        /// <summary>
        /// GET call for creating a new author.
        /// </summary>
        /// <returns>View for creating a new author.</returns>
        [HttpGet]
        public IActionResult CreateAuthor()
        {
            return View();
        }

        /// <summary>
        /// POST call for creating a new author.
        /// </summary>
        /// <param name="author">Author entity to create.</param>
        /// <returns>
        /// Returns the same form if validation fails.
        /// Redirects to authors main page on success.
        /// </returns>
        [HttpPost]
        public IActionResult CreateAuthor(Author author)
        {
            // Remove id check from model state because database automatically assigns id
            ModelState.Remove("Id");

            if (!ModelState.IsValid) // Check if the model is valid
            {
                return View(author); // Return to the same form with errors
            }

            _context.AuthorCreate(author); // Save the new author
            ModelState.Clear(); // Clear the form
            return Redirect("/#authors"); // Redirect to authors main page
        }

        /// <summary>
        /// DELETE call for deleting an author.
        /// </summary>
        /// <param name="id">ID of the author to delete.</param>
        /// <returns>Redirects to authors main page.</returns>
        public IActionResult DeleteAuthor(int id)
        {
            _context.AuthorDelete(id); // Delete the author
            return Redirect("/#authors"); // Redirect to authors main page
        }

        /// <summary>
        /// GET call for retrieving an author's details.
        /// </summary>
        /// <param name="id">ID of the author to view details.</param>
        /// <returns>
        /// View containing detailed author and associated book information.
        /// </returns>
        [HttpGet]
        public IActionResult DetailAuthor(int id)
        {
            var author = _context.GetAuthorById(id); // Retrieve author by ID
            var book = _context.AuthorBooks(author); // Retrieve books by the author

            var model = new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
                Books = book
            };

            return View(model); // Send author details and books to the view
        }

        /// <summary>
        /// GET call for listing all authors in the database.
        /// </summary>
        /// <returns>View containing a list of all authors.</returns>
        public IActionResult Index()
        {
            var authors = _context.GetAuthors(); // Retrieve all authors
            return View(authors); // Send the list of authors to the view
        }
    }
}
