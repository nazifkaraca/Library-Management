using Library.DAL.Context;
using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    /// <summary>
    /// Service class to handle operations related to authors.
    /// </summary>
    public class AuthorService : IAuthorService
    {
        /// <summary>
        /// Database context for accessing the library data.
        /// </summary>
        private readonly LibraryContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorService"/> class.
        /// </summary>
        /// <param name="context">The database context to access authors and books.</param>
        public AuthorService(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all books written by the specified author.
        /// </summary>
        /// <param name="author">The author whose books are to be retrieved.</param>
        /// <returns>A collection of books written by the specified author.</returns>
        public ICollection<Book> AuthorBooks(Author author)
        {
            return _context.Books
                           .Where(x => x.AuthorId == author.Id) // Filter books by author ID
                           .ToList();
        }

        /// <summary>
        /// Adds a new author to the database.
        /// </summary>
        /// <param name="author">The author entity to be created.</param>
        public void AuthorCreate(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes an author from the database by their ID.
        /// </summary>
        /// <param name="id">The ID of the author to be deleted.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the author is not found in the database.</exception>
        public void AuthorDelete(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);

            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Author not found.");
            }
        }

        /// <summary>
        /// Updates the information of an existing author.
        /// </summary>
        /// <param name="author">The author entity containing updated information.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the author is not found in the database.</exception>
        public void AuthorUpdate(Author author)
        {
            var existingAuthor = _context.Authors.FirstOrDefault(x => x.Id == author.Id);

            if (existingAuthor != null)
            {
                existingAuthor.FirstName = author.FirstName;
                existingAuthor.LastName = author.LastName;
                existingAuthor.DateOfBirth = author.DateOfBirth;

                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Author not found.");
            }
        }

        /// <summary>
        /// Retrieves an author by their ID.
        /// </summary>
        /// <param name="id">The ID of the author to retrieve.</param>
        /// <returns>The author entity if found; otherwise, null.</returns>
        public Author GetAuthorById(int id)
        {
            return _context.Authors.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Retrieves all authors from the database.
        /// </summary>
        /// <returns>A list of all authors in the database.</returns>
        public List<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }
    }
}
