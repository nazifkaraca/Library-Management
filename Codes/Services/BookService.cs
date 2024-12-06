using Library.DAL.Context;
using Library.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    /// <summary>
    /// Service class for managing book-related operations.
    /// </summary>
    public class BookService : IBookService
    {
        /// <summary>
        /// Database context for accessing the library data.
        /// </summary>
        private readonly LibraryContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        /// <param name="context">The database context to access books and authors.</param>
        public BookService(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new book to the database.
        /// </summary>
        /// <param name="book">The book entity to be created.</param>
        public void BookCreate(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a book from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to be deleted.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the book with the specified ID is not found.</exception>
        public void BookDelete(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Book with ID ({id}) was not found.");
            }
        }

        /// <summary>
        /// Updates the details of an existing book.
        /// </summary>
        /// <param name="book">The book entity containing updated information.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the book with the specified ID is not found.</exception>
        public void BookUpdate(Book book)
        {
            var existingBook = _context.Books.FirstOrDefault(x => x.Id == book.Id);

            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Genre = book.Genre;
                existingBook.AuthorId = book.AuthorId;
                existingBook.PublishDate = book.PublishDate;
                existingBook.ISBN = book.ISBN;
                existingBook.CopiesAvailable = book.CopiesAvailable;

                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Book was not found.");
            }
        }

        /// <summary>
        /// Retrieves a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>The book entity if found; otherwise, null.</returns>
        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Retrieves all books from the database.
        /// </summary>
        /// <returns>A list of all books in the database.</returns>
        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
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
