using Library.DAL.Context;
using Library.DAL.Entities;

namespace Library.Services
{
    public class BookService : IBookService
	{
		private readonly LibraryContext _context;

		public BookService(LibraryContext context)
		{
			_context = context;
		}

		public void BookCreate(Book book)
		{
			_context.Books.Add(book);
			_context.SaveChanges();
		}

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
                throw new KeyNotFoundException($"Kitap Id'si ({id}) bulunamadı.");
            }
		}

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
                throw new KeyNotFoundException("Kitap bulunamadı.");
            }
        }

        public Book GetBookById(int id)
		{
			return _context.Books.FirstOrDefault(x => x.Id == id);
		}

		public List<Book> GetBooks()
		{
			return _context.Books.ToList();
		}
	}
}
