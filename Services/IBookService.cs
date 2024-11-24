using Library.DAL.Entities;

namespace Library.Services
{
	public interface IBookService
	{
		List<Book> GetBooks();
		Book GetBookById(int id);
		void BookCreate(Book book);
		void BookUpdate(Book book);
		void BookDelete(int id);

		List<Author> GetAuthors();
    }
}
