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
			Book book = _context.Books.FirstOrDefault(x => x.Id == id);

			if (book == null)
			{
				throw new KeyNotFoundException($"Kitap Id'si ({id}) bulunamadı.");
			}

			_context.Books.Remove(book);
			_context.SaveChanges();
		}

		public void BookUpdate(int id)
		{
			Book book = _context.Books.FirstOrDefault(x => x.Id == id);

			if (book != null)
			{
				_context.Update(book);
				_context.SaveChanges();
			}
			else
			{
				throw new KeyNotFoundException($"Kitap Id'si ({id}) bulunamadı.");
			}
		}

		public List<Book> GetAllBooks()
		{
			return _context.Books.ToList();
		}

		public Book GetBookById(int id)
		{
			Book book = _context.Books.FirstOrDefault(x => x.Id == id);

			if (book != null)
			{
				return book;
			}

			throw new KeyNotFoundException($"Kitap Id'si ({id}) bulunamadı.");
		}
	}
}
